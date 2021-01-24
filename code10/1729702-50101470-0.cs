    public static IEnumerable<PropertyInfo> GetProperties(this Type type, int depth = 1)
    {
        IEnumerable<PropertyInfo> getProperties(Type currentType, int currentDepth)
        {
            if (currentDepth >= depth)
                yield break;
            foreach (var property in currentType.GetProperties())
            {
                yield return property;
                foreach (var subProperty in getProperties(property.PropertyType,
                                                          currentDepth + 1))
                {
                    yield return subProperty;
                }
            }
        }
        if (depth < 1)
            throw new ArgumentOutOfRangeException(nameof(depth));
        return getProperties(type, 0);    
    }
