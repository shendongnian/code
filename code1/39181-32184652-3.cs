    public static class PropertyExtension{       
       public static void SetPropertyValue(this object p_object,                                     string p_propertyName, object value)
       {
        PropertyInfo property = p_object.GetType().GetProperty(p_propertyName);
        property.SetValue(p_object, Convert.ChangeType(value, property.PropertyType), null);
       }
    }
