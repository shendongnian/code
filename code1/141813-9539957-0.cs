    public object GetPropertyValue(object obj, string propertyName)
    {
        foreach (var prop in propertyName.Split('.').Select(s => obj.GetType().GetProperty(s)))
           obj = prop.GetValue(obj, null);
        return obj;
    }
