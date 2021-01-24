    string wordToRemove = "{\"result\":[]}";
	if (response.Contains(wordToRemove))
	{
		var datareceived = JsonConvert.DeserializeObject<RootObject>(response.Replace(wordToRemove, String.Empty));
	}
	else
	{
		var datareceived = JsonConvert.DeserializeObject<RootObject>(response);
	}
