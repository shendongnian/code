    using System.Linq; // For Parallel.ForEach(...)
    
    ...
    
    long n = long.Parse(Console.ReadLine());
	List<string> res;
	var stopwatch = new Stopwatch();
	stopwatch.Start();
	res = new List<string>();
	long n2 = n * n;
	// Compute x's upper bound
	double maxX = 0.5 * (2.0 * n - Math.Sqrt(2) * Math.Sqrt(n2 + 1L));
    // --- Remove this if not using Parallel ---
	int nbX = Convert.ToInt32(maxX);
	var xList = Enumerable.Range(1, nbX - 1).ToArray();
    // -----------------------------------------
	// Loop on x first because it's the most constrained
	Parallel.ForEach(xList, x =>
	{
		// Compute y's upper bound
		int maxY = Convert.ToInt32(Math.Floor((n2 - 2.0 * n * x - 1.0) / (2.0 * n - 2.0 * x)));
		// Loop on y with x as lower bound
		for (long y = x; y <= maxY; y++)
		{
			// Compute unique z
			double z = Math.Sqrt(x * x + y * y + 1L);
			// Check if z is integer and the sum constraint is respected
			// The precision is limited to a double's
			if (z == Math.Round(z) && x + y + z <= n)
				res.Add(x + "," + y + "," + z);
		}
	});
	
	stopwatch.Stop();
	Console.WriteLine("N=" + n + "\t Solutions: " + res.Count);
	Console.WriteLine("Time elapsed: " + stopwatch.Elapsed.TotalMilliseconds);
	Console.ReadLine();
