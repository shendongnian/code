    public static IEnumerable<Type> GetTypesFromNamespace(Assembly assembly, 
                                                   String desiredNamepace)
    {
        return assembly.GetTypes()
                       .Where(type => type.Namespace == desiredNamespace);
    }
