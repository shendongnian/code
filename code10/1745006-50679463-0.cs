	public static IEnumerable<int> GetIntsDivisible(int start, int finish, int divisor)
	{
		for (var i = start; i <= finish; i++)
			if (i % 5 == 0)
				yield return i;
	}
	public static void Main()
	{
        Console.WriteLine(string.Join(", ", GetIntsDivisible(1, 100, 5)));
	}
