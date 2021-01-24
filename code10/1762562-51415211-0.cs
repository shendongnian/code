	var map = new Dictionary<string, object>()
	{
		{ "Param1", true },
		{ "Param2", "False" },
		{ "Param3", 123 },
		{ "Param4", "1234" },
	};
	var script = " I have Param1 and Param2 and Param3 and Param4 ";
	
	var output = map.Aggregate(script,
		(s, kvp) => s.Replace(kvp.Key, kvp.Value is string ? $"\"{kvp.Value}\"" : kvp.Value.ToString()));
