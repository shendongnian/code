    public string ReadLine(int timeOutMillisecs)
	{
		var inputBuilder = new StringBuilder();
		var task = Task.Factory.StartNew(() =>
		{
			while (true)
			{
				var consoleKey = Console.ReadKey(true);
				if (consoleKey.Key == ConsoleKey.Enter)
				{
					return inputBuilder.ToString();
				}
				inputBuilder.Append(consoleKey.KeyChar);
			}
		});
		var success = task.Wait(timeOutMillisecs);
		if (!success)
		{
			throw new TimeoutException("User did not provide input within the timelimit.");
		}
		return inputBuilder.ToString();
	}
