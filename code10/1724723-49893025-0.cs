    public static IEnumerable<string> GetFullPropertyName(Type baseType, string propertyName)
    {
        var prop = baseType.GetProperty(propertyName);
        if(prop != null)
        {
            return new[] { prop.Name };
        }
        else if(baseType.IsClass && baseType != typeof(string)) // Do not go into primitives (condition could be refined, this excludes all structs and strings)
        {
            return baseType
                .GetProperties()
                .SelectMany(p => GetFullPropertyName(p.PropertyType, propertyName), (p, v) => p.Name + "." + v);
        }
        return Enumerable.Empty<string>();
    }
