	var myDict = new Dictionary<string, string>();    
	myDict.Add("SomeKey1", "SomeValue");
	myDict.Add("SomeKey2", "SomeValue");
	myDict.Add("MyKey_B" + Guid.NewGuid(), "SomeValue");
	myDict.Add("MyKey_A" + Guid.NewGuid(), "SomeValue");
	myDict.Add("MyKey_C" + Guid.NewGuid(), "SomeValue");
		
	var pairsToRemove = myDict.Where(x => x.Key.StartsWith("MyKey_"))
                              .OrderByDescending(x => x.Key)
                              .Take(2);
		
	foreach (var pair in pairsToRemove)
	{
		myDict.Remove(pair.Key);
    }
		
	foreach (var pair in myDict)
	{
		Console.WriteLine(pair);
	}
