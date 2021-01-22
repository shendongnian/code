    var tokens = input.Split(new[]{' ','\t','\n','\r'}, StringSplitOptions.RemoveEmptyEntries);
    var oregex = new ORegex("{0}{0}{1}{1}", IsText, IsDate);
    
    var matches = oregex.Matches(tokens); //here is your subsequence tokens.
    ...
    public bool IsText(string str)
    {
        ...
    }
    
    public bool IsDate(string str)
    {
        ...
    }
