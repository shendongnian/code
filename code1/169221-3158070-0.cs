    public static string SomeWellNamedExtension(this string s)
    {
        if(string.IsNullOrEmpty(s))
            return "";
        
        return string.Format("({0})", s);
    }
