    string input = "IF;Thermal >=20 and SYSTEM_TIME >= Tue 15 Sep 2009    23:00:21 ";
    string pattern = @"[A-Z]+\s+\d+\s+[A-Z]+\s+\d{4}\s+(?:\d+:){2}\d{2}";
    Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
    
    if (match.Success)
    {
    	string result = match.Value;
    	DateTime parsedDateTime;
    	if (DateTime.TryParse(result, out parsedDateTime))
    	{
    		// successful parse, date is now in parsedDateTime
    		Console.WriteLine(parsedDateTime);
    	}
    	else
    	{
    		// parse failed, throw exception
    	}
    }
    else
    {
    	// match not found, do something, throw exception
    }
