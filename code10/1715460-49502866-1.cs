	static public int ReadIntegerFromConsole(string prompt)
	{
		int result;
		while (true)
		{
			Console.WriteLine(prompt);
			var input = Console.ReadLine();
			var ok = int.TryParse(input, out result);
			if (ok) break;
			Console.WriteLine("That isn't a valid integer.");
		}
		return result;
	}
	static public void DisplaySum(int userNumber, int randomNumber, int delay)
	{
		var sum = userNumber + randomNumber;
		Thread.Sleep(delay);
		Console.WriteLine("The total of {0} + {1} = {2}", userNumber, randomNumber, sum);
	}
