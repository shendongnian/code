    public static class PropertyExtension{       
       public static void SetPropertyValue(this object p_object, 
                                           string p_propertyName, object value)
       {
        PropertyInfo property = p_object.GetType().GetProperty(p_propertyName);
        Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
        object safeValue = (p_value == null) ? null : Convert.ChangeType(p_value, t);
        property.SetValue(p_object, safeValue, null);
       }
    }
