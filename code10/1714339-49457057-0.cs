	const string expected = "Radio%20Signal%20Gabriel%20Moraes%2Cfernando%20De%20S%C3%A1";
	string input = "Radio Signal Gabriel Moraes,fernando De Sá";
		
	var functionDict = new Dictionary<string, Func<string, string>>()
	{
		{ "HttpUtility.UrlPathEncode", x => HttpUtility.UrlPathEncode(x) },
		{ "Uri.EscapeDataString", x => Uri.EscapeDataString(x) },
		{ "Uri.EscapeUriString", x => Uri.EscapeUriString(x) },
		{ "HttpUtility.UrlEncode", x => HttpUtility.UrlEncode(x) }
	};
	
	Console.WriteLine("Functions that match expected output:");
	
	foreach(var f in functionDict)
	{
		string result = f.Value(input);
		
		if(string.Compare(result, expected) == 0)
		{
			Console.WriteLine(f.Key);
		}
	}
