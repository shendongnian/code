    public void Add<T>(string key, T value)
    {
        if (value.ToString() != "")
        {
            Attributes.Add(key + "=\"" + value + "\" ");
        }
    }
