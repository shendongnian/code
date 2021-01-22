    public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
    {
        if (!type.IsInterface)
            return type.GetProperties();
        return (new Type[] { type })
               .Concat(type.GetInterfaces())
               .SelectMany(i => i.GetProperties());
    }
