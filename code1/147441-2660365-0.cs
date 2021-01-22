    static object CastBoxedValue(object value, Type destType)
    {
        if (value == null)
            return value;
        Type enumType = GetEnumType(destType);
        if (enumType != null)
            return Enum.ToObject(enumType, value);
        return value;
    }
    private static Type GetEnumType(Type type)
    {
        if (type.IsEnum)
            return type;
        if (type.IsGenericType)
        {
            var genericDef = type.GetGenericTypeDefinition();
            if (genericDef == typeof(Nullable<>))
            {
                var genericArgs = type.GetGenericArguments();
                return (genericArgs[0].IsEnum) ? genericArgs[0] : null;
            }
        }
        return null;
    }
