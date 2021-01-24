	var strings = response.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
	if (strings.Length > 1)
	{
		foreach (var str in strings)
		{
			Rootobject1 items = JsonConvert.DeserializeObject<Rootobject>(str);
			if (items.result.Length > 0)
			{
				break;
			}
		}
	}
