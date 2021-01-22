    var list = new List<int>(new[] { 1, 2, 4, 7, 9 }); // Assumes list is ordered at this point
    
    list.Insert(0, 0);   // No error checking, just put in the lowest and highest possibles.
    list.Add(10);        // For real world processing, put in check and if not represented then add it/them.
    
    var missing = new List<int>();    // Hold any missing values found.
    
    list.Aggregate ((seed, aggr) =>   // Seed is the previous #, aggr is the current number.
    {
    	var diff = (aggr - seed) -1;  // A difference between them indicates missing.
    	
    	if (diff > 0)                 // Missing found...put in the missing range.
    		missing.AddRange(Enumerable.Range((aggr - diff), diff));
    	
    	return aggr;	
    });
