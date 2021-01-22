    public static string Replace(this string s, IEnumerable<string> strings, string replacementstring)
    {
        foreach (var s1 in strings)
        {
            s = s.Replace(s1, replacementstring);
        }
        
        return s;
    }
