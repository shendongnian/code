    public bool IsAlpha(string input)
    {
    	return Regex.IsMatch(input, "^[a-zA-Z]+$");
    }
    
    public bool IsAlphaNumeric(string input)
    {
    	return Regex.IsMatch(input, "^[a-zA-Z0-9]+$");
    }
    
    public bool IsAlphaNumericWithUnderscore(string input)
    {
    	return Regex.IsMatch(input, "^[a-zA-Z0-9_]+$");
    }
