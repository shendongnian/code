	var strings = response.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
	if (strings.Length > 1)
	{
		List<Rootobject> allResultSet = new List<Rootobject>();
		foreach (var str in strings)
		{
			Rootobject items = JsonConvert.DeserializeObject<Rootobject>(str);
			if (items.result.Length > 0)
			{
				allResultSet.Add(items);
			}
		}
	}
