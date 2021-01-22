    //Class global
    private Assembly configurationDefiningAssembly;
    protected TConfig GetCustomConfig<TConfig>(string configDefiningAssemblyPath, 
        string configFilePath, string sectionName) where TConfig : ConfigurationSection
    {
        AppDomain.CurrentDomain.AssemblyResolve += new 
            ResolveEventHandler(ConfigResolveEventHandler);
        configurationDefiningAssembly = Assembly.LoadFrom(configDefiningAssemblyPath);
        var exeFileMap = new ExeConfigurationFileMap();
        exeFileMap.ExeConfigFilename = configFilePath;
        var customConfig = ConfigurationManager.OpenMappedExeConfiguration(exeFileMap, 
            ConfigurationUserLevel.None);
        var returnConfig = customConfig.GetSection(sectionName) as TConfig;
        AppDomain.CurrentDomain.AssemblyResolve -= ConfigResolveEventHandler;
        return returnConfig;
    }
    protected Assembly ConfigResolveEventHandler(object sender, ResolveEventArgs args)
    {
        return configurationDefiningAssembly;
    }
