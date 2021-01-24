	public static List<double> GetTheList(int count, double target)
	{
		var random = new Random();
		var iteration = 0;
		
		while (true)
		{
			iteration++;
			
			//Start with a list of random numbers of any range
			var list = Enumerable.Range(1, count).Select( i => random.NextDouble() );
			
			//Take the sum
			var sum = list.Sum();
			
			//Determine a scaling factor to make the sum hit the target
			var scale = target / sum;
			
			//Scale all of the numbers, and round them off
			var results = list.Select( n => Math.Round(n * scale, 2) ).ToList();
			
			//Check to see if rounding errors put you off target
			if (Math.Abs(results.Sum() - target) > 0.005) continue;
			
			//Ensure bounds
			if (results.Min() < 0.01 || results.Max() > 99.9) continue;
			
			//The list matches all the criteria, so return it
    		Console.WriteLine("{0} iterations executed.", iteration);
	    	return results;
		}
	}
