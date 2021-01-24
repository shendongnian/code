    class Program
	{
		public enum Month
		{
			January, February, March,
			April, May, June, July, August,
			Septemper, October, November, December
		};
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number of the month");
			int monthValue = 0;
			int.TryParse(Console.ReadLine(), out monthValue);
			Console.WriteLine((Month)monthValue - 1);
			Console.ReadKey();
		}
	}
