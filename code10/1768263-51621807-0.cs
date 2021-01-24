	var serializer = new DataContractJsonSerializer(typeof(RootObject), new DataContractJsonSerializerSettings()
	{
		UseSimpleDictionaryFormat = true
	});
	var json = @"{
    ""Jhon"": { ""Name"": ""John""},
    ""Lucy"": {},
    ""Robert"": {}
    }";
	var bytes = Encoding.UTF8.GetBytes(json);
	using (var stream = new MemoryStream(bytes))
	{
		var results = serializer.ReadObject(stream);
	}
    // Define other methods and classes here
    public class RootObject : Dictionary<string, User>
    {
    }
    public class User
    {
    	public string Name { get; set; }
    }
