    public bool IsAlpha(string input)
    {
    	return new Regex("^[a-zA-Z]+$").IsMatch(input);
    }
    
    public bool IsAlphaNumeric(string input)
    {
    	return new Regex("^[a-zA-Z0-9]+$").IsMatch(input);
    }
    
    public bool IsAlphaNumericWithUnderscore(string input)
    {
    	return new Regex("^[a-zA-Z0-9_]+$").IsMatch(input);
    }
