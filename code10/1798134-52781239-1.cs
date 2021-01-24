    public static string GetRecursivePropertyValues(object obj)
    {
        var properties = new List<string>();
        foreach (var property in obj.GetType().GetProperties())
        {
            object currentPropertyValue = property.GetValue(obj);
            if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
                properties.Add($"{property.Name}:{currentPropertyValue}");
            else
            {
                var subProperties = GetRecursivePropertyValues(currentPropertyValue);
                properties.Add(subProperties);
            }
        }
        return string.Join(";", properties);
    }
