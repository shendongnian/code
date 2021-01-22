    var expectedAssemblyName = new AssemblyName(name);
    var actualAssemblyName = AssemblyName.GetAssemblyName(path);
    if (AssemblyName.ReferenceMatchesDefinition(expectedAssemblyName, actualAssemblyName))
    {
        // Some assemblies
    }
