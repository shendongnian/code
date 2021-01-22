	Dictionary<String,Object> parameters = new Dictionary<String,Object>();
	// cast a string
	parameters.Add("DatabaseName", "SomeBase");
	
	// cast a list
	parameters.Add("Classes", new List<int> { int.Parse("11"), int.Parse("12"), int.Parse("13") });
	
	// cast an integer
	parameters.Add("IntValue", int.parse("3"));
	
	// cast a double
	parameters.Add("DoubleValue", Double.Parse("4.0"));
	
