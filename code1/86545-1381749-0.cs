    public static string FixUp(string s)
    {
        if (s.Length <= 30)
            return s;
        if (s[29] != ' ')
            return s.Insert(30, "-<br />");
        return s.Insert(30, "<br />");
    }
    
