	public class Foo
	{
		[JsonExtensionData]
		public Dictionary<string, JToken> ExtensionData {get; set;}
	}
    dynamic obj = JsonConvert.DeserializeObject<Foo>(json).ExtensionData.Single().Value;
	Console.WriteLine(obj.success);
	Console.WriteLine(obj.data.name);
