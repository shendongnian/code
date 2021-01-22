    private static IList<Type> loadAllImplementingTypes(Type[] interfaces)
    {
        IList<Type> implementingTypes = new List<Type>();
        // find all types
        foreach (var interfaceType in interfaces)
            foreach (var currentAsm in AppDomain.CurrentDomain.GetAssemblies())
                try
                {
                    foreach (var currentType in currentAsm.GetTypes())
                        if (interfaceType.IsAssignableFrom(currentType) && currentType.IsClass && !currentType.IsAbstract)
                            implementingTypes.Add(currentType);
                }
                catch { }
        return implementingTypes;
    }
