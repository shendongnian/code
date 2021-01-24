	var list = new List<string>() { "A1", "A1" };
	
	Console.WriteLine(list.Count);         // 2, obviously
	
	var distinct = list.Distinct();        // select only the *distinct* values
	Console.WriteLine(distinct.Count());   // 1 - because there is only 1 distinct value
	
	var groups = list.GroupBy(s => s);     // group your list (there will only be one
                                           // in this case)
	
	foreach (var g in groups)              // for each group
	{
        // Display the number of items with the same key
		Console.WriteLine(g.Key + ":" + g.Count());   
	}
