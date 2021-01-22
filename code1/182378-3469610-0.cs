    Match m1 = Regex.Match(line, "(((identity)(=)('|\")(\\s*)('|\"))");
    Match m2 = Regex.Match(line, "((frameworkSiteID)(=)('|\")(\\s*)('|\")))");
    
    if (m1.Success && m2.Success) 
    {
        //...
    }
