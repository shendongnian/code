    private static IList<Type> loadAllTypes(Types[] interfaces)
    {
        IList<Type> objects = new List<Type>();
        // find all types
        foreach (var interfaceType in interfaces)
            foreach (var currentAsm in AppDomain.CurrentDomain.GetAssemblies())
                try
                {
                    foreach (var currentType in currentAsm.GetTypes())
                        if (interfaceType.IsAssignableFrom(currentType) && currentType.IsClass && !currentType.IsAbstract)
                            objects.Add(currentType);
                }
                catch { }
        return objects;
    }
