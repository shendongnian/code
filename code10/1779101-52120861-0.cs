	var lanes = 3;
	var racers = 6;
	var except = Enumerable.Range(racers + 1, 10 - racers - 1).Select(r => r).ToList();
	except.Add(0);
	var rows = Enumerable
	 	// Each digit position is a lane
		.Range(0, (Int32)Math.Pow(10, lanes))
		// Remove non-valid racers
		.Where(e => e.ToString().ToList().Select(x => Int32.Parse(x.ToString())).Except(except).Count() == lanes)		
		// Randomize
		.OrderBy(e => Guid.NewGuid()) 
		.ToList()	
		.Dump();	
