    public static Dictionary<string, object> ToDictionary(this object o)
    {
        var dictionary = new Dictionary<string, object>();
    
        foreach (var propertyInfo in o.GetType().GetProperties())
        {
            if (propertyInfo.GetIndexParameters().Length == 0)
            {
                dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(o, null));
            }
        }
    
        return dictionary;
    }
