    var expectedAssemblyName = new AssemblyName(fullName);
    var assemblyName = AssemblyName.GetAssemblyName(path);
    if (AssemblyName.ReferenceMatchesDefinition(expectedAssemblyName, assemblyName))
    {
        // Some assemblies
    }
