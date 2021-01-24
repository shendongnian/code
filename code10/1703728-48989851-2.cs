	IDictionary<string, object> idict = new Dictionary<string, object>();
	idict.Add("sessionData_Department", "1");
	idict.Add("systemData_SerialNumber", "1");
	IEnumerable<IDictionary<string, object>> row = new List<IDictionary<string, object>> { idict };
	var val = new ViewTable
	{
		Id = 15,
		Rows = row
	};
	var cc = new CamelCasePropertyNamesContractResolver
	{
		NamingStrategy = new CamelCaseDictionaryKeyNamingStrategy()
	};
	JsonSerializerSettings config = new JsonSerializerSettings
	{
		Formatting = Formatting.Indented,
		ContractResolver = cc,
		ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
		TypeNameHandling = TypeNameHandling.Auto
	};
	string js = JsonConvert.SerializeObject(val, config);
	
	
