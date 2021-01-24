        public enum Month
		{
			January = 1, February, March,
			April, May, June, July, August,
			Septemper, October, November, December
		};
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number of the month");
			var input = Enum.Parse(typeof(Month), Console.ReadLine());
			Console.WriteLine(input);
			Console.ReadKey();
		}
