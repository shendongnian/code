    public IEnumerable<string> Combine(IEnumerable<string> col1, IEnumerable<string> col2)
    {
        foreach(string item in col1)
            yield return item;
    
        foreach(string item in col2)
            yield return item;
    }
