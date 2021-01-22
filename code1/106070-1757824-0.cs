    public static IEnumerable<Type> GetImplementations(Type interfaceType)
    {
        // this will load the types for all of the currently loaded assemblies in the
        // current domain.
    
        return GetImplementations(interfaceType, AppDomain.CurrentDomain.GetAssemblies());
    }
    
    public static IEnumerable<Type> GetImplementations(Type interfaceType, IEnumerable<Assembly> assemblies)
    {
        return assemblies.SelectMany(
            assembly => assembly.GetExportedTypes()).Where(
                t => interfaceType.IsAssignableFrom(t)
            );
    }
