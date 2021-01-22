    public PropertyInfo GetProp(Type baseType, string propertyName)
    {
        string[] parts = propertyName.Split('.');
        
        return (parts.Length > 1) ? GetProp(baseType.GetProperty(parts[0]).PropertyType, parts.Skip(1).Aggregate((a,i) => a + "." + i)) : baseType.GetProperty(propertyName);
    }
