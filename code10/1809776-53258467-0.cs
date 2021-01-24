    public static IEnumerable<Assembly> GetReferencingAssemblies(string assemblyName)
    {
        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default.RuntimeLibraries;
        foreach (var library in dependencies)
        {
            if (IsCandidateLibrary(library, assemblyName))
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }
        }
        return assemblies;
    }
    
    private static bool IsCandidateLibrary(RuntimeLibrary library, assemblyName)
    {
        return library.Name == (assemblyName)
            || library.Dependencies.Any(d => d.Name.StartsWith(assemblyName));
    }
