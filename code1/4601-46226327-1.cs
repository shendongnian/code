		static void Main()
		{
			Console.WriteLine("howdy");
			string result = ConsoleReadLineWithTimeout(TimeSpan.FromSeconds(8.5));
			Console.WriteLine("bye");
		}
