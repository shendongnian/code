    private static string MyMethod(string s)
    {
        StringBuilder sb = new StringBuilder(s.Length);
        foreach (var g in s.ToCharArray().GroupBy(c => c))
            if (g.Count() == 1) sb.Append(g.Key);
    
        return sb.ToString();
    }
