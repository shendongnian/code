    public bool FilterByName(string value)
    {
        return value.StartsWith("R");
    }
    // .. later
    List<string> strings = new List<string> { "Reed", "Fred", "Sam" };
    var stringsStartingWithR = strings.Where(FilterByName);
