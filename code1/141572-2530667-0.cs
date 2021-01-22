    try
    {
    	Regex regexObj = new Regex("</?[a-z][a-z0-9]*[^<>]*>", RegexOptions.IgnoreCase);
    	Match matchResults = regexObj.Match(subjectString);
    	while (matchResults.Success)
        {
            // Do Stuff
            // matched text: matchResults.Value
            // match start: matchResults.Index
            // match length: matchResults.Length
            matchResults = matchResults.NextMatch();
    	} 
    }
    catch (ArgumentException ex)
    {
    	// Syntax error in the regular expression
    }
