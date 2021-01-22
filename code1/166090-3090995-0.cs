    public String parse(String keyword)
    {
        if (string.IsNullOrEmpty(keyword))
            return string.Empty;
    
        var retVal = (from v in keyword.ToArray()
                        select v.ToString())
                        .Aggregate((a, b) => a + "/" +b);
    
        return retVal;
    }
