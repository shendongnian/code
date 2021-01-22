    private Dictionary<char, int> baseChars;
    
    // I don't know what your class is called.
    public MultipleBaseNumberFormatter(IEnumerable<char> baseCharacters)
    {
        // check for baseCharacters != null and Count > 0
    
        baseChars = baseCharacters
            .Select((c, i) => new { Value = c, Index = i })
            .ToDictionary(x => x.Value, x => x.Index);
    }
