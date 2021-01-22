    public static bool IsGenericList(this object obj)
    {
        return IsGenericList(obj.GetType());
    }
    public static bool IsGenericList(this Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }
        foreach (Type @interface in type.GetInterfaces())
        {
            if (@interface.IsGenericType)
            {
                if (@interface.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    // if needed, you can also return the type used as generic argument
                    return true;
                }
            }
        }
        return (type.GetInterface("IEnumerable") != null);
    }
