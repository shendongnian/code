    public static bool IsNullable(this Type type)
    {
        return type.IsClass
            || (type.IsGeneric && type.GetGenericTypeDefinition == typeof(Nullable<>));
    }
