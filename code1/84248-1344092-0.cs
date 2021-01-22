    public static string RemoveDuplicates(string source)
    {
        HashSet<char> found = new HashSet<char>();
        HashSet<char> dupes = new HashSet<char>();
        foreach (char c in source)
        {
            if (!found.Add(c))
            {
                dupes.Add(c);
            }
        }
        StringBuilder sb = new StringBuilder(source.Length);
        foreach (char c in source)
        {
            if (!dupes.Contains(c))
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
