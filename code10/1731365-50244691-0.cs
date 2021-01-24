    private async Task<List<Assembly>> GetAssemblyListAsync()
    {
        var PackageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
    
        List<Assembly> assemblies = new List<Assembly>();
        foreach (StorageFile file in await PackageFolder.GetFilesAsync())
        {
            if (file.FileType == ".dll" || file.FileType == ".exe")
            {
                AssemblyName name = new AssemblyName() { Name = file.Name };
                Assembly asm = Assembly.Load(name);
                assemblies.Add(asm);
            }
        }
        return assemblies;
    }
