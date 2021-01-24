	string json = "{\"TYPE\":\"TABLE1\",\"CreatedDate\":\"2018-06-10T08:00:00.000Z\",\"CreatedBy\":\"John\",\"ID\":\"1\",\"ADDRESS\":\"1 Road Street\",\"TABLE2\":[{\"CreatedDate\":\"2018-06-10T08:00:00.000Z\",\"CreatedBy\":\"John\",\"ID\":\"2\",\"ADDRESS\":\"2 Road Street\"}]}";
	var settings = new JsonSerializerSettings()
	{
		Converters = new List<JsonConverter>()
		{
			new AbstractEntityConverter()
		}
	};
	var obj = JsonConvert.DeserializeObject<AbstractEntity>(json, settings);
