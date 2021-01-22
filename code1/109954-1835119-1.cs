    PropertyInfo[] typeProperties = GetType().GetProperties();
    var nullableProperties = typeProperties.Where(property => 
        property.PropertyType.IsGenericType &&
        property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>));
    
    var attributes = new Dictionary<string, string>();
    foreach (var nullableProperty in nullableProperties)
    {
        object value = nullableProperty.GetValue(this,null);
        attributes.Add(nullableProperty.Name, value == null ? 
                                                    string.Empty : value.ToString());
    }
