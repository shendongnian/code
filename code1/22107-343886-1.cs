    public static IEnumerable<Type> GetTypesFromNamespace(Assembly assembly, 
                                                   String desiredNamespace)
    {
        return assembly.GetTypes()
                       .Where(type => type.Namespace == desiredNamespace);
    }
