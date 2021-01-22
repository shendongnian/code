    public object this[string key]
    {
        get
        {
            object value;
            _innerDictionary.TryGetValue(key, out value);
            return value;
        }
        set { _innerDictionary[key] = value; }
    }
