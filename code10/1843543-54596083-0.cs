    //Grou pand aggregate the data
	var results = overrideList
		.GroupBy(l => l.RID)
		.Select(l =>
		{
			var dictionary = new Dictionary<string, int>();
			dictionary.Add("RID", l.Key);
			foreach (var pidValue in l)
			{
				dictionary.Add($"PID_{pidValue.PID}", int.Parse(pidValue.Value));
			}
			return dictionary;
		});
    //Throw the data into our output class
	var output = new Output
	{
		Overrides = results
	};
    //Convert to JSON
    var json = JsonConvert.SerializeObject(output);
