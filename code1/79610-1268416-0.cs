    public IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
    {
        return assembly.GetTypes().Where(t => t != baseType && 
                                              baseType.IsAssignableFrom(t));
    }
