	Random baseRandom = new Random(0);
	int DuplicateIntegerTest(int interations)
	{
		Random r = new Random(baseRandom.Next());
		int[] ints = new int[interations];
		for (int i = 0; i < ints.Length; i++)
		{
			ints[i] = r.Next();
		}
		Array.Sort(ints);
		for (int i = 1; i < ints.Length; i++)
		{
			if (ints[i] == ints[i - 1])
				return 1;
		}
		return 0;
	}
	void DoTest()
	{
		baseRandom = new Random(0);
		int count = 0;
		int duplicates = 0;
		for (int i = 0; i < 1000; i++)
		{
			count++;
			duplicates += DuplicateIntegerTest(77163);
		}
		Console.WriteLine("{0} iterations had {1} with duplicates", count, duplicates);
	}
	
	1000 iterations had 737 with duplicates
