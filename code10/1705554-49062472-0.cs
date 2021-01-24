	Console.Write("Enter the number of tests: ");
	int n = int.Parse(Console.ReadLine());
	Console.WriteLine("----------------------------------------");
	Console.WriteLine("Please enter the test scores");
	int AskForInteger()
	{
		while (true)
		{
			int i = Convert.ToInt32(Console.ReadLine());
			if (i >= 0 && i <= 100)
			{
				return i;
			}
			Console.WriteLine("Please enter a value between 0 and 100 inclusive");
		}
	}
	int[] scores =
		Enumerable
			.Range(0, n)
			.Select(x => AskForInteger())
			.ToArray();
	Console.WriteLine("The sum of all the scores is {0}", scores.Sum());
	Console.ReadLine();
