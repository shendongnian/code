	class Test
	{
		private static void Main()
		{
			Random rand = new Random();
			for (int i = 0; i < 25; ++i)
			{
				Console.WriteLine(rand.Next(1000000000, int.MaxValue));
			}
		}
	}
