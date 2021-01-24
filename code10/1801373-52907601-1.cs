   	private static string FullFaStar = "full";
	private static string HalfFaStar = "half";
	private static string EmptyFaStar = "empty";
	static void Main(string[] args)
	{
		Console.WriteLine($"Value {0}");
		GetStarts(0);
		Console.WriteLine($"Value {0.8m}");
		GetStarts(0.8m);
		Console.WriteLine($"Value {2.4m}");
		GetStarts(2.4m);
		Console.WriteLine($"Value {3.2m}");
		GetStarts(3.2m);
		Console.WriteLine($"Value {4.5m}");
		GetStarts(4.5m);
		Console.WriteLine($"Value {5m}");
		GetStarts(5m);
		Console.ReadLine();
	}
	private static string GetStarts(decimal sum)
	{
		string fa = string.Empty;
		for (int currentCount = 0; currentCount < 5; currentCount++)
		{
			if (sum >= currentCount)
			{
				fa = FullFaStar;
			}
			else if ((sum - currentCount) >= 0.5m)
			{
				fa = HalfFaStar;
			}
			else if (((sum - currentCount) < 0.5m))
			{
				fa = EmptyFaStar;
			}
			Console.WriteLine($"start {currentCount}: {fa}");
		}
		return fa;
	}
