    public static List<string> GetNameVariations(string name)
    {
        var results = name.Select((t, i) =>
            name.Substring(0, i) + name.Substring(i + 1, name.Length - (i + 1)))
            .ToList();
        results.Add(name);
        return results;
    }
