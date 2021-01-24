	private void TestJson()
	{
		var jsonSettings = new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Auto,
			TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
		};
		var myObj = new MyObject
		{
			Type = typeof(string)
		};
		var serialize = JsonConvert.SerializeObject(myObj, jsonSettings);
		var newObj = JsonConvert.DeserializeObject<MyObject>(serialize, jsonSettings);
	}
