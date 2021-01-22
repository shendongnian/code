    public static string GetDomain(this IIdentity identity)
    {
        string s = identity.Name;
        int stop = s.IndexOf("\\");
        return (stop > -1) ?  s.Substring(0, stop + 1) : string.Empty;
    }
    
    public static string GetLogin(this IIdentity identity)
    {
        string s = identity.Name;
        int stop = s.IndexOf("\\");
        return (stop > -1) ? s.Substring(stop + 1, s.Length - stop - 1) : string.Empty;
    }
