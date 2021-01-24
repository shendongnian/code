    private static void ListAllOrderedPropertiesOfType(Type targetType)
    {
        // Generate a list containing the whole hierarchy of classes, from the base type to the type T
        var typesList = new List<Type>();
        for (Type t = targetType; t != typeof(Object); t = t.BaseType)
            typesList.Insert(0, t);
    
        // Iterate from the base type to type T, printing the properties defined for each of the types
        foreach (Type t in typesList)
        {
            PropertyInfo[] propertyInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var propInfo in propertyInfos)
                Console.WriteLine(propInfo.Name);
        }
    }
