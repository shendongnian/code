    public bool IsNullableEnum(this Type t)
    {
        return t.IsGenericType &&
               t.GetGenericTypeDefinition() == typeof(Nullable<>) &&
               t.GetGenericArguments()[0].IsEnum;
    }
