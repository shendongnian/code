    static Type GetIEnumerableElementType(Type type)
    {
        if (type.IsGenericType &&
            !type.IsGenericTypeDefinition &&
            type.GetGenericTypeDefinition().IsAssignableFrom(typeof(IEnumerable<>))
        {
            return type.GetGenericArguments()[0];
        }
        return null;
    }
