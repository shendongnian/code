    Add(string key, string value) { dictionary.Add(key.ToLowerInvariant(), value) ; }
    public string this[string key]
    {
        get { return dictionary[key.ToLowerInvariant()]; }
        set { dictionary[key.ToLowerInvariant()] = value; }
    }
    // And so forth.
