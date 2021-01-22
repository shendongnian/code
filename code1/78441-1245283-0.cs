    public static string ToDelimitedString(this IEnumerable<string> source, string delimiter)
    {
        string d = "";
        var result = new StringBuilder();
        foreach( string s in source)
        {
           result.Append(d).Append(s);
           d = delimiter;
        } 
        return result.ToString();
    }
