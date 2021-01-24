	using System;
	public class Program
	{
		public static void Main()
		{
			int x;
			Console.WriteLine("Find a number that can be divided by both 7 and 12");
			while (true)
			{ //Loop the code until it is broken out of
				x = int.Parse(Console.ReadLine());
				if ((x % 7 == 0) && (x % 12 == 0))
				{
					Console.WriteLine("well done, " + x + " can be divided by 7 and 12");
					Console.ReadKey(); //Pause the program so it doesnt break out immediately
					break; //Break out of the while loop
				}
				else
				{
					Console.WriteLine("Wrong, try again.");
				}
			}
		}
	}
