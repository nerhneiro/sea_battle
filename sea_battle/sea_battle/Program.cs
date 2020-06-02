using System;
using System.Threading;
namespace sea_battle
{
	class Program
	{
		static void fill(string[,] comp)
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++) comp[i, j] = "☐";
			}
		}
		static void writeline_out(string[,] comp, string[,] user)
		{
			Console.WriteLine("     ПОЛЕ КОМПЬЮТЕРА          ПОЛЕ ИГРОКА ");
			Console.WriteLine("   a б в г д е ж з и к     a б в г д е ж з и к");
			for (int i = 0; i < 10; i++)
			{
				Console.Write("{0} ", i + 1);
				if (i != 9) Console.Write(" ");
				for (int j = 0; j < 10; j++)
				{
					Console.Write("{0} ", comp[i, j]);
				}
				Console.Write(" ");
				Console.Write("{0} ", i + 1);
				if (i != 9) Console.Write(" ");
				for (int j = 0; j < 10; j++)
				{
					Console.Write("{0} ", user[i, j]);
				}
				Console.WriteLine();
			}
		}
		static void shot_into_user(string[,] user_pole, string[,] user, int[] shot, int[] shot1, string[,] user_end, string[,] comp_field)
		{
			var rand = new Random();
			if (shot1[1] == shot[1] && shot1[0] == shot[0])
			{
				shot[0] = rand.Next(0, 10);
				shot[1] = rand.Next(0, 10);
			}
			if (shot[0] > 0 && user_pole[shot[0] - 1, shot[1]] == "x" && user[shot[0] - 1, shot[1]] == "☐" || shot[1] > 0 && user_pole[shot[0], shot[1] - 1] == "x" && user[shot[0], shot[1] - 1] == "☐" || shot[0] < 9 && user_pole[shot[0] + 1, shot[1]] == "x" && user[shot[0] + 1, shot[1]] == "☐" || shot[1] < 9 && user_pole[shot[0], shot[1] + 1] == "x" && user[shot[0], shot[1] + 1] == "☐" || shot[1] > 0 && shot[0] > 0 && user_pole[shot[0] - 1, shot[1] - 1] == "x" && user[shot[0] - 1, shot[1] - 1] == "☐" || shot[0] > 0 && shot[1] < 9 && user_pole[shot[0] - 1, shot[1] + 1] == "x" && user[shot[0] - 1, shot[1] + 1] == "☐" || shot[0] < 9 && shot[1] > 0 && user_pole[shot[0] + 1, shot[1] - 1] == "x" && user[shot[0] + 1, shot[1] - 1] == "☐" || shot[0] < 9 && shot[1] < 9 && user_pole[shot[0] + 1, shot[1] + 1] == "x" && user[shot[0] + 1, shot[1] + 1] == "☐")
			{
				shot[0] = rand.Next(0, 10);
				shot[1] = rand.Next(0, 10);
				shot_into_user(user_pole, user, shot, shot1, user_end, comp_field);
			}
			if (user_pole[shot[0], shot[1]] == "☐" && user[shot[0], shot[1]] != "☐")
			{
				Console.WriteLine("Компьютер попал!");
				user_pole[shot[0], shot[1]] = "x";
				user[shot[0], shot[1]] = "x";
				writeline_out(comp_field, user);
				Thread.Sleep(2000);
				shot = next(user_pole, user, shot, user_end);
				if (shot1 == shot)
				{
					shot[0] = rand.Next(0, 10);
					shot[1] = rand.Next(0, 10);
				}
				shot_into_user(user_pole, user, shot, shot1, user_end, comp_field);
			}
			else if (user_pole[shot[0], shot[1]] == "☐" && user[shot[0], shot[1]] == "☐")
			{
				Console.WriteLine("Мимо!");
				user_pole[shot[0], shot[1]] = "∙";
				user[shot[0], shot[1]] = "∙";
			}
			else if (user_pole[shot[0], shot[1]] == "∙")
			{
				shot[0] = rand.Next(0, 10);
				shot[1] = rand.Next(0, 10);
				shot_into_user(user_pole, user, shot, shot1, user_end, comp_field);
			}

			shot1[0] = shot[0];
			shot1[1] = shot[1];
		}
		static int[] next(string[,] user_pole, string[,] user, int[] shot, string[,] user_end)
		{
			var rand = new Random();
			writeline_out(user_pole, user_end);
			if (user_end[shot[0], shot[1]] == "1")
			{
				Console.WriteLine("зашел");
				if (shot[0] < 9) { user_pole[shot[0] + 1, shot[1]] = "∙"; user[shot[0] + 1, shot[1]] = "∙"; }
				if (shot[0] > 0) { user_pole[shot[0] - 1, shot[1]] = "∙"; user[shot[0] - 1, shot[1]] = "∙"; }
				if (shot[1] < 9) { user_pole[shot[0], shot[1] + 1] = "∙"; user[shot[0], shot[1] + 1] = "∙"; }
				if (shot[1] > 0) { user_pole[shot[0], shot[1] - 1] = "∙"; user[shot[0], shot[1] - 1] = "∙"; }
				if (shot[0] > 0 && shot[1] > 0) { user_pole[shot[0] - 1, shot[1] - 1] = "∙"; user[shot[0] - 1, shot[1] - 1] = "∙"; }
				if (shot[0] > 0 && shot[1] < 9) { user_pole[shot[0] - 1, shot[1] + 1] = "∙"; user[shot[0] - 1, shot[1] + 1] = "∙"; }
				if (shot[0] < 9 && shot[1] > 0) { user_pole[shot[0] + 1, shot[1] - 1] = "∙"; user[shot[0] + 1, shot[1] - 1] = "∙"; }
				if (shot[0] < 9 && shot[1] < 9) { user_pole[shot[0] + 1, shot[1] + 1] = "∙"; user[shot[0] + 1, shot[1] + 1] = "∙"; }
				shot[0] = rand.Next(0, 10);
				shot[1] = rand.Next(0, 10);
			}
			else if (user_end[shot[0], shot[1]] == "2")
			{
				if (shot[0] > 0 && user_end[shot[0] - 1, shot[1]] == "2") { shot[0]--; if (shot[1] < 9) user_pole[shot[0], shot[1] + 1] = "∙"; if (shot[1] > 0) user_pole[shot[0], shot[1] - 1] = "∙"; if (shot[0] > 0) user_pole[shot[0] - 1, shot[1]] = "∙"; if (shot[0] > 0 && shot[1] > 0) user_pole[shot[0] - 1, shot[1] - 1] = "∙"; if (shot[0] < 9 && shot[1] < 9) user_pole[shot[0] + 1, shot[1] + 1] = "∙"; if (shot[0] < 8) user_pole[shot[0] + 2, shot[1]] = "∙"; if (shot[0] < 8 && shot[1] < 9) user_pole[shot[0] + 2, shot[1] + 1] = "∙"; if (shot[0] < 8 && shot[1] > 0) user_pole[shot[0] + 2, shot[1] - 1] = "∙"; }
				else if (shot[0] < 9 && user_end[shot[0] + 1, shot[1]] == "2") shot[0]++;
				else if (shot[1] > 0 && user_end[shot[0], shot[1] - 1] == "2") shot[1]--;
				else if (shot[1] < 9 && user_end[shot[0], shot[1] + 1] == "2") shot[1]++;
			}

			else if (user_end[shot[0], shot[1]] == "3")
			{
				if (shot[0] > 0 && user_end[shot[0] - 1, shot[1]] == "3" && user_pole[shot[0] - 1, shot[1]] != "x") shot[0]--;
				else if (shot[0] > 0 && user_end[shot[0] - 1, shot[1]] == "3" && user_pole[shot[0] - 1, shot[1]] != "x")
				{
					if (shot[0] < 9 && user_end[shot[0] + 1, shot[1]] == "3") shot[0]++;
					else shot[0] -= 2;
				}
				else if (shot[0] < 8 && user_pole[shot[0] + 1, shot[1]] == "x" && user_end[shot[0] + 2, shot[1]] == "3") shot[0] += 2;
				else if (shot[1] > 0 && user_end[shot[0], shot[1] - 1] == "3") shot[1]--;
				else if (shot[1] < 9 && user_end[shot[0], shot[1] + 1] == "3") shot[1]++;
				else if (shot[1] > 1 && user_end[shot[0], shot[1] - 2] == "3" && user_pole[shot[0], shot[1] - 1] == "3") shot[1] -= 2;
				else if (shot[1] < 8 && user_pole[shot[0], shot[1] + 1] == "x" && user_pole[shot[0], shot[1] + 2] == "3") shot[1] += 2;
				else if (shot[0] > 0 && shot[0] < 9 && user_pole[shot[0] - 1, shot[1]] == "x" && user_end[shot[0] + 1, shot[1]] == "3") shot[0]++;
				else if (shot[0] < 9 && user_end[shot[0], shot[1] + 1] == "3") shot[0]++;
				else if (shot[0] < 8 && user_end[shot[0], shot[1] + 2] == "3") shot[0] += 2;
			}
			else if (user_end[shot[0], shot[1]] == "4")
			{
				if (shot[1] < 9 && user_end[shot[0], shot[1] + 1] == "4") shot[1]++;
				else if (shot[1] > 0 && user_end[shot[0], shot[1] - 1] == "4") shot[1]--;
				else if (shot[0] > 0 && user_end[shot[0] - 1, shot[1]] == "4") shot[0]--;
				else if (shot[0] < 9 && user_end[shot[0] + 1, shot[1]] == "4") shot[0]++;
				else if (shot[1] > 1 && user_end[shot[0], shot[1] - 2] == "4") shot[1] -= 2;
				else if (shot[1] > 2 && user_end[shot[0], shot[1] - 3] == "4") shot[1] -= 3;
				else if (shot[1] < 8 && user_end[shot[0], shot[1] + 2] == "4") shot[1] += 2;
				else if (shot[1] < 7 && user_end[shot[0], shot[1] + 3] == "4") shot[1] += 3;
			}
			return shot;
		}
		static bool check(string[,] comp, string a)
		{
			int k = 0;
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++) if (comp[i, j] == a) k++;
			}
			if (k == 20) return true;
			else return false;
		}
		static void user_goes(int[] ans, string[,] comp_field, string[,] comp)
		{
			if (comp[ans[1], ans[0]] == "☐")
			{
				Console.WriteLine("МИМО!");
				comp_field[ans[1], ans[0]] = "∙";
			}
			if (comp[ans[1], ans[0]] != "☐")
			{
				Console.WriteLine("Вы попали!");
				comp_field[ans[1], ans[0]] = "x";

			}
			if (comp[ans[1], ans[0]] == "1")
			{
				Console.WriteLine("зашел");
				if (ans[1] < 9) { comp_field[ans[1] + 1, ans[0]] = "∙"; comp[ans[1] + 1, ans[0]] = "∙"; }
				if (ans[1] > 0) { comp_field[ans[1] - 1, ans[0]] = "∙"; comp[ans[1] - 1, ans[0]] = "∙"; }
				if (ans[0] < 9) { comp_field[ans[1], ans[0] + 1] = "∙"; comp[ans[1], ans[0] + 1] = "∙"; }
				if (ans[0] > 0) { comp_field[ans[1], ans[0] - 1] = "∙"; comp[ans[1], ans[0] - 1] = "∙"; }
				if (ans[1] > 0 && ans[0] > 0) { comp_field[ans[1] - 1, ans[0] - 1] = "∙"; comp[ans[1] - 1, ans[0] - 1] = "∙"; }
				if (ans[1] > 0 && ans[0] < 9) { comp_field[ans[1] - 1, ans[0] + 1] = "∙"; comp[ans[1] - 1, ans[0] + 1] = "∙"; }
				if (ans[1] < 9 && ans[0] > 0) { comp_field[ans[1] + 1, ans[0] - 1] = "∙"; comp[ans[1] + 1, ans[0] - 1] = "∙"; }
				if (ans[1] < 9 && ans[0] < 9) { comp_field[ans[1] + 1, ans[0] + 1] = "∙"; comp[ans[1] + 1, ans[0] + 1] = "∙"; }
			}
		}
		static void one(int[] ans, string[,] comp, string[,] comp_field)
		{
			if (ans[1] < 9) { comp_field[ans[1] + 1, ans[0]] = "∙"; comp[ans[1] + 1, ans[0]] = "∙"; }
			if (ans[1] > 0) { comp_field[ans[1] - 1, ans[0]] = "∙"; comp[ans[1] - 1, ans[0]] = "∙"; }
			if (ans[0] < 9) { comp_field[ans[1], ans[0] + 1] = "∙"; comp[ans[1], ans[0] + 1] = "∙"; }
			if (ans[0] > 0) { comp_field[ans[1], ans[0] - 1] = "∙"; comp[ans[1], ans[0] - 1] = "∙"; }
			if (ans[1] > 0 && ans[0] > 0) { comp_field[ans[1] - 1, ans[0] - 1] = "∙"; comp[ans[1] - 1, ans[0] - 1] = "∙"; }
			if (ans[1] > 0 && ans[0] < 9) { comp_field[ans[1] - 1, ans[0] + 1] = "∙"; comp[ans[1] - 1, ans[0] + 1] = "∙"; }
			if (ans[1] < 9 && ans[0] > 0) { comp_field[ans[1] + 1, ans[0] - 1] = "∙"; comp[ans[1] + 1, ans[0] - 1] = "∙"; }
			if (ans[1] < 9 && ans[0] < 9) { comp_field[ans[1] + 1, ans[0] + 1] = "∙"; comp[ans[1] + 1, ans[0] + 1] = "∙"; }
		}
		static int number(string[] mas)
		{
			int number = -1;
			if (mas[0] == "А") number = 0;
			if (mas[0] == "Б") number = 1;
			if (mas[0] == "В") number = 2;
			if (mas[0] == "Г") number = 3;
			if (mas[0] == "Д") number = 4;
			if (mas[0] == "Е") number = 5;
			if (mas[0] == "Ж") number = 6;
			if (mas[0] == "З") number = 7;
			if (mas[0] == "И") number = 8;
			if (mas[0] == "К") number = 9;
			return number;
		}
		//"x"
		static void Main(string[] args)
		{
			string[,] comp = { { "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐" }, { "☐", "2", "☐", "☐", "1", "☐", "☐", "3", "3", "3" }, { "☐", "2", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐" }, { "☐", "☐", "☐", "3", "3", "3", "☐", "☐", "2", "☐" }, { "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "2", "☐" }, { "☐", "☐", "☐", "☐", "☐", "4", "☐", "☐", "☐", "☐" }, { "☐", "☐", "2", "2", "☐", "4", "☐", "☐", "☐", "☐" }, { "☐", "☐", "☐", "☐", "☐", "4", "☐", "1", "☐", "☐" }, { "☐", "1", "☐", "☐", "☐", "4", "☐", "☐", "☐", "☐" }, { "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "1", "☐" } };
			string[,] comp_field = new string[10, 10];
			fill(comp_field);
			string[,] var1 = { { "☐", "☐", "☐", "☐", "☐", "☐", "☐", "2", "2", "☐" }, { "☐", "☐", "3", "3", "3", "☐", "☐", "☐", "☐", "☐" }, { "1", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "1" }, { "☐", "☐", "☐", "☐", "☐", "☐", "1", "☐", "☐", "☐" }, { "☐", "☐", "2", "☐", "☐", "☐", "☐", "☐", "☐", "☐" }, { "☐", "☐", "2", "☐", "☐", "☐", "☐", "☐", "4", "☐" }, { "☐", "☐", "☐", "☐", "☐", "1", "☐", "☐", "4", "☐" }, { "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "4", "☐" }, { "2", "2", "☐", "☐", "☐", "☐", "☐", "☐", "4", "☐" }, { "☐", "☐", "☐", "☐", "3", "3", "3", "☐", "☐", "☐" } };
			string[,] user = var1;
			string[,] user_end = { { "☐", "☐", "☐", "☐", "☐", "☐", "☐", "2", "2", "☐" }, { "☐", "☐", "3", "3", "3", "☐", "☐", "☐", "☐", "☐" }, { "1", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "1" }, { "☐", "☐", "☐", "☐", "☐", "☐", "1", "☐", "☐", "☐" }, { "☐", "☐", "2", "☐", "☐", "☐", "☐", "☐", "☐", "☐" }, { "☐", "☐", "2", "☐", "☐", "☐", "☐", "☐", "4", "☐" }, { "☐", "☐", "☐", "☐", "☐", "1", "☐", "☐", "4", "☐" }, { "☐", "☐", "☐", "☐", "☐", "☐", "☐", "☐", "4", "☐" }, { "2", "2", "☐", "☐", "☐", "☐", "☐", "☐", "4", "☐" }, { "☐", "☐", "☐", "☐", "3", "3", "3", "☐", "☐", "☐" } };
			string[,] user_field = new string[10, 10];
			fill(user_field);
			var rand = new Random();
			int[] shot = new int[2];
			shot[0] = rand.Next(0, 9);
			shot[1] = rand.Next(0, 9);
			int[] shot1 = new int[2];
			shot1[0] = shot[0];
			shot1[1] = shot[1];
			bool check1 = false;
			bool check2 = false;
			int[] ans = new int[2]; string[] answer;
			while (check1 != true || check2 != true)
			{
				writeline_out(comp_field, user);
				Console.WriteLine("Пользователь, ваш ход");
				answer = Console.ReadLine().Split(' ');
				ans[0] = number(answer);
				ans[1] = int.Parse(answer[1]) - 1;
				user_goes(ans, comp_field, comp);
				Console.WriteLine("Теперь ход компьютера");
				shot_into_user(user_field, user, shot, shot1, user_end, comp_field);
				check1 = check(comp_field, "x");
				check2 = check(user_field, "x");
			}
			if (check1 == check2) Console.WriteLine("Ничья! Поздравляю!");
			else if (check1 == true) Console.WriteLine("Поздравляю! Ты победил искусственный интеллект! Ты просто гений!");
			else Console.WriteLine("К сожалению, искусственный интеллект одержал над тобой победу... Но не отчаивайся, ведь ты дал отличный бой. Попробуй сыграть еще!");
		}
	}
}
