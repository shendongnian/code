    public static IEnumerable<int> IndexesOf(string haystack, string needle)
    {
           Regex r = new Regex("\\b(" + needle + ")\\b");
           MatchCollection m = r.Matches(haystack);
                   
           return from Match o in m select o.Index;
    }
