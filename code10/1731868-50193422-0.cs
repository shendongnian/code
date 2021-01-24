    List<Regex> Filters = new List<Regex>();
    Filters.Add(new Regex("string1", RegexOptions.IgnoreCase, RegexOptions.Compiled));
    Filters.Add(new Regex("string2", RegexOptions.Compiled));
    string target = "string which may contain string1 or string2 or neither";
    if (Filters.Any(x => x.IsMatch(target)))
    {
        // do stuff }
    }
