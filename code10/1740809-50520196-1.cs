	static int[] generateRandomSequence(int count, int max)
	{
		Random rn = new Random();
		int[] seq = new int[count];
		for (int i = 0; i < count; ++i)
		{
			seq[i] = rn.Next(0, max + 1);
		}
		return seq;
	}
	static void OutputSequence(int[] array)
	{
		for (int i = 0; i < array.Length; ++i)
		{
			if (i > 0)
			{
				Console.Write(", ");
			}
			Console.Write(array[i]);
		}
		Console.WriteLine();
	}
