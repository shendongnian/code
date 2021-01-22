    public static string ValueOrDefault(this string s, string sDefault)
    {
        if (string.IsNullOrEmpty(s))
            return sDefault;
        return s;
    }
