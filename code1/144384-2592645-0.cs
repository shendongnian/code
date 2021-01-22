    string resultString = null;
    
    try
    {
        resultString = Regex.Match(subjectString, "Hello[, -]*this", RegexOptions.IgnoreCase).Value;
    }
    catch (ArgumentException ex)
    {
    	// Syntax error in the regular expression
    }
