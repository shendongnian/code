	var source = "Hello {name}!";
	
    //Using Dictionary:
	var dict = new Dictionary<string, string> { { "name", "David" } };
	var greeting1 = source.Replace(dict);
	Console.WriteLine(greeting1);
    //Using an anonymous object:
	var greeting2 = source.Replace(new { name = "David" });
	Console.WriteLine(greeting2);
