    private static string FormatJson(string json)
	{
		dynamic parsedJson = JsonConvert.DeserializeObject(json);
		return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
	}
