    public QueryStringParser(string QueryString)
    {
        this._mode = DetermineMode(QueryString);
    }
    
    private Mode DetermineMode(string QueryString)
    {
        // Input is NULL STRING
        if (string.IsNullOrEmpty(QueryString))
            return Mode.First;
    
        // Query using FirstName
        if (QueryString.Contains(_FristFieldName) && !QueryString.Contains(_SecondFieldName))
            return Mode.Second;
    
        //Query using SecondName
        if (!QueryString.Contains(_FristFieldName) && QueryString.Contains(_SecondFieldName))
            return Mode.Third;
    
        //Insufficient info to Query data
        throw new ArgumentException("QueryString has wrong format");
    }
