    public static bool HasGenericDefinition(this Type type, Type definition)
    {
        return GetTypeWithGenericDefinition(type, definition) != null;
    }
    public static Type GetTypeWithGenericDefinition(this Type type, Type definition)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        if (definition == null)
            throw new ArgumentNullException("genericTypeDefinition");
        if (!definition.IsGenericTypeDefinition)
            throw new ArgumentException(
                "definition must be a GenericTypeDefinition", "definition");
        if (definition.IsInterface)
        {
            foreach (var interfaceType in type.GetInterfaces())
                if (interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == definition)
                    return interfaceType;
        }
        for (Type t = type; t != null; t = t.BaseType)
            if (t.IsGenericType &&
                t.GetGenericTypeDefinition() == definition)
                return t;
        return null;
    }
