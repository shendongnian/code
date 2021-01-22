    StringCollection resultList = new StringCollection();
    try 
    {
        Regex regexObj = new Regex("\"([^\"]+)\"");
        Match matchResult = regexObj.Match(subjectString);
        
        while (matchResult.Success) 
        {
            resultList.Add(matchResult.Groups[1].Value);
            matchResult = matchResult.NextMatch();
        } 
    }
    catch (ArgumentException ex) 
    {
        // Syntax error in the regular expression
    }
