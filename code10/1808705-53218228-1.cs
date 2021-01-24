	var list = new List<string>();
	list.Add("11:03:01:003 INFO some event has occurred");
	list.Add("11:03:31:004 DEBUG another event has occurred");
	list.Add("11:04:01:015 INFO third event has occurred");
	
	var list2 = new List<string>();
	list2.Add("11:03:16:003 INFO fourth event has occurred");
	list2.Add("11:03:32:025 DEBUG fifth event has occurred");
	list2.Add("11:03:54:023 INFO sixth event has occurred");
	
	var result = list
        // Merge both lists
		.Union(list2)
		.Select(x => 
		{ 
			return new { Log = x, Time = TimeSpan.Parse(x.Split(' ')[0]) }; 
		})
		.OrderBy(x => x.Time)
		.ToArray();
	
	foreach (var log in result)
    {
		Console.WriteLine(log.Time + " => " + log.Log);
	}
