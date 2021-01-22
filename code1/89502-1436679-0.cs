    public static DateTime? GetValue(string input)
    {
        DateTime? val = string.IsNullOrEmpty(input) ? null : (DateTime?)DateTime.Parse(input); 
        return val;
    }
