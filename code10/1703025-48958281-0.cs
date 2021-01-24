	public static void Main()
	{
		var cityPopulation = new Dictionary<string, int>
        {
			{"Sacramento",495234 },
			{"Miami",     453579 },
			{"Memphis",   652717 }
        };
		
		var sortedPopulation = cityPopulation.OrderBy( a => a.Key );
		string[] cities = sortedPopulation.Select( a => a.Key ).ToArray();
		int[] populations = sortedPopulation.Select( a => a.Value ).ToArray();
		
		foreach (var c in cities)
			Console.WriteLine(c);
		foreach (var p in populations)
			Console.WriteLine(p);
	}
