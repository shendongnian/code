    public IEnumerable<Assembly> LoadAssemblies()
    {
        DirectoryInfo directory = new DirectoryInfo(@"c:\mybinfolder");
        FileInfo[] files = directory.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
        
        foreach (FileInfo file in files)
        {
            // Load the file into the application domain.
            AssemblyName assemblyName = AssemblyName.GetAssemblyName(file.FullName);
            Assembly assembly = AppDomain.CurrentDomain.Load(assemblyName);
            yield return assembly;
        } 
    
        yield break;
    }
