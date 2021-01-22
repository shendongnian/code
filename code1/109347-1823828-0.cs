    public void Add(string key, object value)
    {
        string valueString = value.ToString();
        if (!string.IsNullOrEmpty(valueString))
        {
            Attributes.Add(key + "=\"" + valueString + "\" ");
        }
    } 
    
