	public T? GetKey<T>(string key) where T : struct
	{
		string content = CrossSettings.Current.GetValueOrDefault(key, null);
		if (content == null)
			return null;
		return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
	}
