    public void PreLoad()
    {
        this.AssembliesFromApplicationBaseDirectory();
    }
    
    void AssembliesFromApplicationBaseDirectory()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        this.AssembliesFromPath(baseDirectory);
                
        string privateBinPath = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
        if (Directory.Exists(privateBinPath))
            this.AssembliesFromPath(privateBinPath);
    }
    
    void AssembliesFromPath(string path)
    {
        var assemblyFiles = Directory.GetFiles(path)
            .Where(file => Path.GetExtension(file).Equals(".dll", StringComparison.OrdinalIgnoreCase));
    
        foreach (var assemblyFile in assemblyFiles)
        {
            // TODO: check it isnt already loaded in the app domain
            Assembly.LoadFrom(assemblyFile);
        }
    }
