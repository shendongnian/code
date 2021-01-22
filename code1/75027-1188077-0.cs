    public static Dictionary<char, int> CountLetters(string value, string letters)
    {
        var counts = letters.ToDictionary(c => c, c => 0, StringComparer.OrdinalIgnoreCase);
        var groups = from c in value
                     where counts.ContainsKey(c)
                     group c by c;
        foreach(var g in groups)
            counts[g.Key] = g.Count();
        return counts;
    }
