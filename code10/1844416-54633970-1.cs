    Entry rollingEntry = null;
    
    foreach (var line in log)
    {
    	var match = Regex.Match(line, LogLineRegex);
    
    	if (match.Success)
    	{
    		if (rollingEntry != null) { entries.Add(rollingEntry); }
    
    		rollingEntry = new Entry{ 
                Timestamp = match.Groups["date"].ToString(),
                Type = match.Groups["type"].ToString(),
                Description = match.Groups["text"].ToString() };
    	}
    	else
    	{
    		if (rollingEntry != null) { rollingEntry.Description += $"{Environment.NewLine}{line}"; }
    	}
    }
