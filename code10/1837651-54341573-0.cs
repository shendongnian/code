	var response = JObject.FromObject(
		new
		{
			Error = new
			{
				Message = "Test",
				Code = ErrorCode.A
			}
		},
		JsonSerializer.CreateDefault(new JsonSerializerSettings { Converters = { new StringEnumConverter() } })
	)
	.ToString(Formatting.None);
