	private static List<ToBeDeserialized> DeserializeAccordingly(string json)
	{
		dynamic data = JsonConvert.DeserializeObject(json);
		IDictionary<string, JToken> quotes = data;
		List<ToBeDeserialized> listOfQuote = new List<ToBeDeserialized>();
		foreach (var quote in quotes)
		{
			var qu = JsonConvert.DeserializeObject<ToBeDeserialized>(quote.Value.ToString());
			listOfQuote.Add(qu);
		}
		return listOfQuote;
	}
