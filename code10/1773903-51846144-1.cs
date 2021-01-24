    // Use this to instantiate objects of types with a large number of int/string fields for testing.  You can override any values after calling this - complex fields won't be set
    //  -sets numeric values on that object to its 'id'
    //  -sets string values on that object to the name of the field concatenated with the 'id'
    public static T CreateObject<T>(int id)
    {
        var instance = (T)Activator.CreateInstance(typeof(T));
    
        // only set properties with a visible setter
        var properties = typeof(T).GetProperties().Where(prop => prop.GetSetMethod() != null);
    
        foreach (var property in properties)
        {
            var type = property.PropertyType;
            if (IsNumeric(type))
            {
                type = Nullable.GetUnderlyingType(type) ?? type;
                var value = Convert.ChangeType(id, type);
    
                property.SetValue(instance, value);
            }
            else if (property.PropertyType == typeof(string))
            {
                property.SetValue(instance, property.Name + id);
            }
            else if (property.PropertyType == typeof(bool))
            {
                property.SetValue(instance, true);
            }
        }
    
        return instance;
    }
    
