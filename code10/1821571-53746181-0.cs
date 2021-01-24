    public static bool IsSimpleType(Type type)
    {
        return
            type.IsPrimitive ||
            new Type[] {
        typeof(Enum),
        typeof(String),
        typeof(Decimal),
        typeof(DateTime),
        typeof(DateTimeOffset),
        typeof(TimeSpan),
        typeof(Guid)
            }.Contains(type) ||
            Convert.GetTypeCode(type) != TypeCode.Object ||
            (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
            ;
    }
    public object GetValueOrNull(object obj)
    {
        if (obj == null) return null;
        Type objType = obj.GetType();
        PropertyInfo[] properties = objType.GetProperties();
        var simpleTypes = properties.Where(t => IsSimpleType(t.PropertyType));
        var nonValueTypes = properties.Where(p => !simpleTypes.Contains(p));
        foreach (var child in nonValueTypes)
        {
            child.SetValue(obj, GetValueOrNull(child.GetValue(obj)));
        }
        return simpleTypes.All(z => z.GetValue(obj) == null) && nonValueTypes.All(z => z.GetValue(obj) == null) ? null : obj;
    }
