    public static bool IsGenericTypeOf(this Type type, Type genericTypeDefinition)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        if (genericTypeDefinition == null)
            throw new ArgumentNullException(nameof(genericTypeDefinition));
        return type.IsGenericType && type.GetGenericTypeDefinition() == genericTypeDefinition;
    }
