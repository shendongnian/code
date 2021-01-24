	var json = JsonConvert.DeserializeObject<dynamic>(JsonData);
	var data = ((JObject)json.Results).Properties().Values().Cast<JObject>().ToArray();
	foreach (var item in data)
	{
		var childss = item.Properties().Values().ToArray();
		foreach (dynamic item2 in childss)
		{
			string hmm = item2.value1;
			Console.WriteLine(hmm);
		}
	}
