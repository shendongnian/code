    private static bool IsList(object value)
    {
        var type = value.GetType();
        var targetType = typeof (IList<>);
        return type.GetInterfaces().Any(i => i.IsGenericType 
                                          && i.GetGenericTypeDefinition() == targetType);
    }
