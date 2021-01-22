    public static IEnumerable<Type> GetIListTypeParameters(Type type)
    {
        // Query.
        return
            from interfaceType in type.GetInterfaces()
            where interfaceType.IsGenericType
            let baseInterface = interfaceType.GetGenericTypeDefinition()
            where baseInterface == typeof(IList<>)
            select interfaceType.GetGenericArguments().First();
    }
