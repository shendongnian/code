    public void Add(string key, object value)
    {
        if (value != null)
        {
            Attributes.Add(key + "=\"" + value.ToString() + "\" ");
        }
    } 
