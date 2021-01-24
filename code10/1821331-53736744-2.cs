	var settings = new JsonSerializerSettings
	{
		ContractResolver = new CamelCasePropertyNamesContractResolver(),
	};
	var root = JsonConvert.DeserializeObject<RootObject>(jsonString, settings);
	
	var json2 = JsonConvert.SerializeObject(root, Formatting.Indented, settings);
