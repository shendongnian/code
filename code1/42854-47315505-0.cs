    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace ConsoleApp1
	{
		class Program
		{
			static void print(int x, int y, int n)
			{
				for(int i = 0; i < 20; i++)
				{
					Console.CursorLeft = x; Console.CursorTop = y++;
					Console.Write(new string(n.ToString().Last(), 60));
				}
			}
			static void Main(string[] args)
			{
				var l = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
				
				while (true)
				{
					Console.Clear();
					Console.CursorVisible = false;
					for (int i = 0; i < l.Count; i++)
					{
						print((i % 3) * 60, (i / 3) * 20, l[i]++);
					}
					
					Task.Delay(1000).Wait();
				}
			}
		}
	}
