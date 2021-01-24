    var key = new Key(new Dictionary<string, object>()
		{
			{ "Property1", "Hi, " },
			{ "Property2", "There" }
		}
	);
	
	Console.WriteLine(key.GetValues()); // Hi, There!
