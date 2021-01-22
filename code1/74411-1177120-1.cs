    public ValidationError Validate<T>(T entityProperty, string[] entityPropertyName)
    {                  
        ICollection<T> businessObjectList = FetchObjectsByType<T>();
        Hashtable properties = EnumeratePropertyInfo(entityProperty, entityPropertyName);
        return businessObjectList.Any(obj => IsDuplicate(obj, properties)) == true ? new ValidationError(_DuplicateMessage) : ValidationError.Empty;
    }
              
    private Hashtable EnumeratePropertyInfo(T entityProperty, string[] entityPropertyName)
    {
        Hashtable properties = new Hashtable();
        for (int i = 0; i < entityPropertyName.Length; i++)        
        {            
            object value = getPropertyValue(entityProperty, entityPropertyName[i]);
            properties.Add(entityPropertyName[i], value);
        }
        return properties;
    }
    // all properties must be matched for a duplicate to be found
    private bool IsDuplicate(T entityProperty, Hashtable properties)
    {
        foreach(DictionaryEntry prop in properties)
        {
            var curValue = getPropertyValue(entityProperty, prop.Key);
            if (prop.Value != curValue)
            {
                return false;
            }
        }
        return true;
    }
