    public static bool Compare<T>(T Object1, T object2)
    {
        //Get the type of the object
        Type type = typeof(T);
    
        //return false if any of the object is false
        if (Object1 == null || object2 == null)
            return false;
    
        //Loop through each properties inside class and get values for the property from both the objects and compare
        foreach (System.Reflection.PropertyInfo property in type.GetProperties())
        {
            if (property.Name != "ExtensionData")
            {
                string Object1Value = string.Empty;
                string Object2Value = string.Empty;
                if (type.GetProperty(property.Name).GetValue(Object1, null) != null)
                    Object1Value = type.GetProperty(property.Name).GetValue(Object1, null).ToString();
                if (type.GetProperty(property.Name).GetValue(object2, null) != null)
                    Object2Value = type.GetProperty(property.Name).GetValue(object2, null).ToString();
                if (Object1Value.Trim() != Object2Value.Trim())
                {
                    return false;
                }
            }
        }
        return true;
    }
