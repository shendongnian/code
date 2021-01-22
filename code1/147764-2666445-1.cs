    public QueryStringParser(string QueryString)
    {
        this._mode = DetermineMode(QueryString);
    }
    
    private Mode DetermineMode(string QueryString)
    {
        // Input is NULL STRING
        if (string.IsNullOrEmpty(QueryString))
            return Mode.First;
    
        bool hasFirst = QueryString.Contains(_FristFieldName);
        bool hasSecond = !QueryString.Contains(_SecondFieldName);
    
        // Query using FirstName
        if (hasFirst && !hasSecond)
            return Mode.Second;
    
        //Query using SecondName
        if (!hasFirst && hasSecond)
            return Mode.Third;
    
        //Insufficient info to Query data
        throw new ArgumentException("QueryString has wrong format");
    }
