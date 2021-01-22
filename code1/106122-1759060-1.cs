    public bool SetProperty(object obj, string PropertyName, object val)
    {
        object property_value = null;
        System.Reflection.PropertyInfo[] properties_info = obj.GetType.GetProperties;
        System.Reflection.PropertyInfo property_info = default(System.Reflection.PropertyInfo);
        
        foreach (System.Reflection.PropertyInfo prop in properties_info) {
            if (prop.Name == PropertyName) property_info = prop; 
        }
        
        if (property_info != null) {
            try {
                property_info.SetValue(obj, val, null);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
        else {
            return false;
        }
    }
    
    public object GetProperty(object obj, string PropertyName)
    {
        object property_value = null;
        System.Reflection.PropertyInfo[] properties_info = obj.GetType.GetProperties;
        System.Reflection.PropertyInfo property_info = default(System.Reflection.PropertyInfo);
        
        foreach (System.Reflection.PropertyInfo prop in properties_info) {
            if (prop.Name == PropertyName) property_info = prop; 
        }
        
        if (property_info != null) {
            try {
                property_value = property_info.GetValue(obj, null);
                return property_value;
            }
            catch (Exception ex) {
                return null;
            }
        }
        else {
            return null;
        }
    }
