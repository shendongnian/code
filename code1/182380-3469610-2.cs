    Match m1 = Regex.Match(line, "(((identity)(=)('|\")(\\s*)('|\"))", RegexOptions.IgnoreCase);
    Match m2 = Regex.Match(line, "((frameworkSiteID)(=)('|\")(\\s*)('|\")))", RegexOptions.IgnoreCase);
    
    if (m1.Success && m2.Success) 
    {
        //...
    }
