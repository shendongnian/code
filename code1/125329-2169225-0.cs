    public static Type GetElementType(Type type)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        if (type.HasElementType)
            return type.GetElementType();
        Type[] interfaces = type.GetInterfaces();
        foreach (Type t in interfaces)
        {
            if (t.IsGenericType)
            {
                Type generic = t.GetGenericTypeDefinition();
                if (generic == typeof(IEnumerable<>))
                    return t.GetGenericArguments()[0];
            }
        }
        return null;
    }
    public static Type GetUnderlyingType(Type type)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        if (type.IsEnum)
            return type.GetEnumUnderlyingType();
        return Nullable.GetUnderlyingType(type);
    }
