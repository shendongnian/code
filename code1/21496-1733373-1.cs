    public void Load(IEnumerable<Assembly> assemblies)
    {
        foreach (Assembly assembly in assemblies)
        {
            this.Load(assembly.GetNinjectModules());
        }
    }
