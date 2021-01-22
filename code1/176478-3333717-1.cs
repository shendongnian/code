    // split the string into rows
    string[] rows = myString.Split('|');
    Dictionary<string, string> pairs = new Dictionary<string, string>();
    foreach (var r in rows)
    {
        // split each row into a pair and add to the dictionary
        string[] split = Regex.Split(r, "::");
        pairs.Add(split[0], split[1]);
    }
