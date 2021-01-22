    public static bool Implements<TInterface>(this Type type) where TInterface : class {
        var interfaceType = typeof(TInterface);
        
        if (!interfaceType.IsInterface)
            throw new InvalidOperationException("Only interfaces can be implemented.");
        return (interfaceType.IsAssignableFrom(type));
    }
