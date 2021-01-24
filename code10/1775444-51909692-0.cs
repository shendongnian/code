var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>>(File.ReadAllText("Data.json"));
To make sure you got the right data you can run this code to print it out:
foreach (var a in data)
{
	Console.WriteLine(a.Key);
	foreach (var b in a.Value)
	{
		Console.WriteLine("\t" + b.Key);
		foreach (var c in b.Value)
		{
			Console.WriteLine("\t\t" + c.Key);
			foreach (var d in c.Value)
			{
				Console.WriteLine("\t\t\t" + d.Key + ": " + d.Value);
			}
		}
	}
}
Not really sure how to deserialize this data to a class since it doesn't have much in the way of property names...
