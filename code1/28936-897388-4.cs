    /// <summary>
    /// Checks whether this type has the specified definition in its ancestry.
    /// </summary>   
    public static bool HasGenericDefinition(this Type type, Type definition)
    {
        return GetTypeWithGenericDefinition(type, definition) != null;
    }
    /// <summary>
    /// Returns the actual type implementing the specified definition from the
    /// ancestry of the type, if available. Else, null.
    /// </summary>
    public static Type GetTypeWithGenericDefinition(this Type type, Type definition)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        if (definition == null)
            throw new ArgumentNullException("definition");
        if (!definition.IsGenericTypeDefinition)
            throw new ArgumentException(
                "The definition needs to be a GenericTypeDefinition", "definition");
        if (definition.IsInterface)
            foreach (var interfaceType in type.GetInterfaces())
                if (interfaceType.IsGenericType
                    && interfaceType.GetGenericTypeDefinition() == definition)
                    return interfaceType;
        for (Type t = type; t != null; t = t.BaseType)
            if (t.IsGenericType && t.GetGenericTypeDefinition() == definition)
                return t;
        return null;
    }
