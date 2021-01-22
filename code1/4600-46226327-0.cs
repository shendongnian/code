		public static string ConsoleReadLineWithTimeout(TimeSpan timeout)
		{
			Task<string> task = Task.Factory.StartNew(Console.ReadLine);
			string result = Task.WaitAny(new Task[] { task }, timeout) == 0
				? task.Result 
				: string.Empty;
			return result;
		}
