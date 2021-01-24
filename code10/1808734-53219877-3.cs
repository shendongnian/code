	var settings = new JsonSerializerSettings
	{
		MissingMemberHandling = MissingMemberHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore,				
		Converters = { new JsonSingleOrEmptyArrayConverter<IDictionary<string, CObject>>() },
	};
	
	var obj = JsonConvert.DeserializeObject<IDictionary<string, CObject>>(Json, settings);
