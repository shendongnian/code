	public List<string> GetJsonItems(string jsonString)
	{
		int bracketCount = 0;
		List<string> jsonItems = new List<string>();
		StringBuilder Json = new StringBuilder();
		foreach (char c in jsonString)
		{
			if (c == '{')
				++bracketCount;
			else if (c == '}')
				--bracketCount;
			Json.Append(c);
			if (bracketCount == 0 && c != ' ')
			{
				jsonItems.Add(Json.ToString());
				Json = new StringBuilder();
			}
		}
		return jsonItems;
	}
	
