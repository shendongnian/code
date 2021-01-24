	public static (string channelName, string channelNumber, string channelValue) ParseUrlData(string urlData)
	{
		var regex = new Regex(@"serial=(\d+)(&c(:\d+)?=(\d+))?");
		var matches = regex.Match(urlData);
		string name = null;
		string number = null;
		string value = null;
		if (matches.Success)
		{
			name = matches.Groups[1].Value;
			if (matches.Groups.Count == 5) number = matches.Groups[3].Value.TrimStart(':');
			if (matches.Groups.Count >= 4) value = matches.Groups[matches.Groups.Count - 1].Value;
		}
		Console.WriteLine($"[{name}] [{number}] [{value}]");
		return (name, number, value);
	}
