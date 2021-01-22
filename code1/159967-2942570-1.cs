	class Test
	{
		private static void Main()
		{
			Random rand = new Random();
			var generatedSoFar = new HashSet<int>();
			for (int i = 0; i < 25; ++i)
			{
				int newRand;
				do
				{
					newRand = rand.Next(1000000000, int.MaxValue);
				} while (generatedSoFar.Contains(newRand)); // generate a new random number until we get to one we haven't generated before
				generatedSoFar.Add(newRand);
				Console.WriteLine(newRand);
			}
		}
	}
