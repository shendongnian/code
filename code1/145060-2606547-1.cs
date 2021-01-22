    public bool NamespaceExists(IEnumerable<Assembly> assemblies, string ns)
    {
        foreach(Assembly assembly in assemblies)
        {
            if(assembly.GetTypes().Any(type => type.Namespace == ns))
                return true;
        }
    
        return false;
    }
