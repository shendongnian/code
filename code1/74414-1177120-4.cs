    public ValidationError Validate<T>(T entityProperty, string[] entityPropertyName)
    {                  
        ICollection<T> businessObjectList = FetchObjectsByType<T>();
        Hashtable properties = EnumeratePropertyInfo<T>(entityProperty, entityPropertyName);
        return businessObjectList.Any(obj => IsDuplicate<T>(obj, properties)) == true ? new ValidationError(_DuplicateMessage) : ValidationError.Empty;
    }
              
    private Hashtable EnumeratePropertyInfo<T>(T entityProperty, string[] entityPropertyName)
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
    private bool IsDuplicate<T>(T entityProperty, Hashtable properties)
    {
        foreach(DictionaryEntry prop in properties)
        {
            var curValue = getPropertyValue(entityProperty, prop.Key.ToString());
            if (!prop.Value.Equals(curValue))
            {
                return false;
            }
        }
        return true;
    }
