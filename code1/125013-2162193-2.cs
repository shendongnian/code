    public object GetPropertyValue(object obj, string propertyIdCode)
    {
        PropertyInfo pinfo = obj.GetType().GetProperty(propertyIdCode);
        return pinfo.GetValue(obj, null);
    }
   
