	var grouped = items.Aggregate(new List<List<SomeType>>() { new List<SomeType>() }, (acc,elem) => 
		{ 
			if(elem.Val == 0 && acc.Last().Count != 0)  
				acc.Add(new List<SomeType>());
			else if(elem.Val == 1)
				acc.Last().Add(elem);
			return acc;
		}, acc => acc.Where(x => x.Count != 0));
	int groupNum = 1;
	foreach (var group in grouped)
	{
		Console.WriteLine($"Group {groupNum++}");
		foreach (var item in group)
			Console.WriteLine($"{item.Id} - {item.Val}");
	}
	
    /* output:
    Group 1
    3 - 1
    4 - 1
    5 - 1
    6 - 1
    Group 2
    11 - 1
    12 - 1
    */
