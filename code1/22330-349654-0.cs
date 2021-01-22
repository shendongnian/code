    public static string GetDomain(string s)
    {
        int stop = s.IndexOf("\\");
        return (stop > -1) ?  s.Substring(0, stop + 1) : null;
    }
    public static string GetLogin(string s)
    {
        int stop = s.IndexOf("\\");
        return (stop > -1) ? s.Substring(stop + 1, s.Length - stop - 1) : null;
    }
