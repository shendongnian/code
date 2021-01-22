    string name = GetAssemblyName (args); //gets just the name part of the assembly name
    foreach (string searchDirectory in m_searchDirectories)
        {
        string assemblyPath = Path.Combine (executingAssemblyPath, searchDirectory);
        assemblyPath = Path.Combine (assemblyPath, name + ".dll");        
        if (File.Exists (assemblyPath))
            {            
            Assembly assembly = Assembly.LoadFrom (assemblyPath);
            if (assembly.FullName == args.Name)
                return assembly;
            }
        }
