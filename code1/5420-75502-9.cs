    public static bool IsAssignableToGenericType(Type givenType, Type genericType) {
        var interfaceTypes = givenType.GetInterfaces();
        foreach (var it in interfaceTypes)
            if (it.IsGenericType)
                if (it.GetGenericTypeDefinition() == genericType) return true;
        Type baseType = givenType.BaseType;
        if (baseType == null) return false;
        return baseType.IsGenericType &&
            baseType.GetGenericTypeDefinition() == genericType ||
            IsAssignableToGenericType(baseType, genericType);
    }
