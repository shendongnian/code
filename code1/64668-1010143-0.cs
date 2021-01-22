    public static string StringFormat(string format, IDictionary<string, string> values)
    {
        foreach(var p in values)
            format = format.Replace("{" + p.Key + "}", p.Value);
        return format;
    }
