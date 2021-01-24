    string a = File.ReadAllText(@"json file path");
    getPropertiesAndValues(a);
    
    private static void getPropertiesAndValues(string json)
    {
	JObject jObject = JObject.Parse(json);
	foreach (JProperty i in jObject.Properties())
	{
		var name = i.Name;
		var value = i.Value;
		Console.Write($"Name: {name} \t\t");
		if (!i.Value.HasValues)
			Console.WriteLine($"Value: {i.Value}");
		Console.WriteLine();
		if (i.HasValues && i.Value.HasValues)
		getPropertiesAndValues(i.First.ToString());
	}
