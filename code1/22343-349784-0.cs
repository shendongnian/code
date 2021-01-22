    public static int? ToInt(this string input) 
    {
        int val;
        if (int.TryParse(input, out val))
            return val;
        return null;
    }
    
    public static DateTime? ToDate(this string input)
    {
        DateTime val;
        if (DateTime.TryParse(input, out val))
            return val;
        return null;
    }
    
    public static decimal? ToDecimal(this string input)
    {
        decimal val;
        if (decimal.TryParse(input, out val))
            return val;
        return null;
    }
