    public Type[] LoadPluginsInAssembly(Assembly otherAssembly)
    {
        List<Type> pluginTypes = new List<Type>();
        foreach (Type type in otherAssembly.GetTypes())
        {
            // This is just a diagnostic. IsAssignableFrom is what you'll use once
            // you find the problem.
            Type otherInterfaceType =
                type.GetInterfaces()
                .Where(interfaceType => interfaceType.Name.Equals(typeof(IPlugin).Name, StringComparison.Ordinal)).FirstOrDefault();
            if (otherInterfaceType != null)
            {
                if (otherInterfaceType == typeof(IPlugin))
                {
                    pluginTypes.Add(type);
                }
                else
                {
                    Console.WriteLine("Duplicate IPlugin types found:");
                    Console.WriteLine("  " + typeof(IPlugin).AssemblyQualifiedName);
                    Console.WriteLine("  " + otherInterfaceType.AssemblyQualifiedName);
                }
            }
        }
        if (pluginTypes.Count == 0)
            return Type.EmptyTypes;
        return pluginTypes.ToArray();
    }
