    public bool NamespaceExists(IEnumerable<Assembly> assemblies, string namespace)
    {
        foreach(Assembly assembly in assemblies)
        {
            if(assembly.GetTypes().Any(type => type.Namespace == namespace))
                return true;
        }
    
        return false;
    }
