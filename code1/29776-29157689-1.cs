	static void Main(string[] args)
	{
		foreach (int i in getRandomsWithTotalA(200, 30, 9))
		{
			Console.Write("{0}, ", i);
		}
		Console.WriteLine("\n");
		foreach (int i in getRandomsWithTotalB(200, 30, 9))
		{
			Console.Write("{0}, ", i);
		}
	}
    3, 8, 7, 5, 9, 9, 8, 9, 9, 6, 8, 7, 4, 8, 7, 7, 8, 9, 2, 7, 9, 5, 8, 1, 4, 5, 4, 8, 9, 7,
    6, 8, 5, 7, 6, 9, 9, 8, 5, 4, 4, 6, 7, 7, 8, 4, 9, 6, 6, 5, 8, 9, 9, 6, 6, 8, 7, 4, 7, 7, 
