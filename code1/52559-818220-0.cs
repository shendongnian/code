    public IDictionary<string, object> GetNonNullProertyValues(object obj)
    {
        var dictionary = new Dictionary<string, object>();
    
        foreach (var property in obj.GetType().GetProperties())
        {
            var propertyValue = property.GetValue(obj, null);
            if (propertyValue != null)
            {
                dictionary.Add(property.Name, propertyValue);
            }
        }
    
        return dictionary;
    }
