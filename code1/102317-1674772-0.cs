    public static string StripNonAlphabets(string input)
    {
        Regex reg = new Regex("[^A-Za-z]");
    
        return reg.Replace(str, string.Empty);
    }
