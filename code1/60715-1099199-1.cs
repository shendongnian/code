    public string this[string key]
    {
        get { return properties.ContainsKey(key) ? properties[key] : null; }
        set
        {
            if (properties.ContainsKey(key))
            {
                properties[key] = value;
            }
            else
            {
                properties.Add(key, value);
            }
        }
    }
