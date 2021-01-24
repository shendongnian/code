    private IDictionary<string, Type> GetProperties<T>()
    {
        var type = typeof(T);
        return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(p => new { Property = p, Attribute = p.GetCustomAttribute<CustomAttributes.GridColumnAttribute>() })
                    .Where(p => p.Attribute != null)
                    .OrderBy(p => p.Attribute.Index)
                    .ToDictionary(p => p.Property.Name, p => p.Property.PropertyType);
    }
