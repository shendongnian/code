    public static Dictionary<char, int> CountLetters(string value, string letters)
    {
        var counts = letters.ToDictionary(c => c.ToString(), c => 0, StringComparer.OrdinalIgnoreCase);
        var groups = from c in value
                     let s = c.ToString()
                     where counts.ContainsKey(s)
                     group s by s;
        foreach(var g in groups)
            counts[g.Key] = g.Count();
        return counts;
    }
