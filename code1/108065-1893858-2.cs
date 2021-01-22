    private IList<string> _mappedProperty;
        
    public IEnumerable<string> ExposedProperty
    {
        get { return _mappedProperty.AsEnumerable<string>(); }
    }
    public void Add(string value)
    {
        // Apply business rules, raise events, queue message, etc.
        _mappedProperty.Add(value);
    }
