    public static IEnumerable<PropertyMetaData> GetPropertiesOrdered(Type someType, int inheritanceLevel = 1)
    {
        List<PropertyMetaData> seenProperties = new List<PropertyMetaData>();
        if (someType.BaseType != (typeof(object)))
            seenProperties.AddRange(GetPropertiesOrdered(someType.BaseType, inheritanceLevel + 1));
        var properties = someType
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Select(a => new PropertyMetaData(a, inheritanceLevel))
            .Where(a => a.AttributeData != null);
            
        properties = properties
            .OrderBy(a => a.AttributeData.ClassOrder)
            .Select((a, ordinal) =>
            {
                a.OrderWithinClass = ordinal + 1;
                return a;
            });                        
            
        return seenProperties
            .Union(properties)
            .OrderByDescending(a => a.InheritanceLevel)
            .ThenBy(a => a.OrderWithinClass)
            .Select((a, ordinal) =>
            {
                a.OrderOverall = ordinal + 1;
                return a;
            });
    }
