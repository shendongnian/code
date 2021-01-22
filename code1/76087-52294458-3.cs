	var nodesDict = new List<IDictionary>();
	foreach (object obj in nodes)
	{
		var ict=MakeDictionary(obj);
		nodesDict.Add(ict);
	}
	if (nodesDict.Any(n => (bool)n["Checked"] == false))
	{
		Console.WriteLine("found!");
	}
