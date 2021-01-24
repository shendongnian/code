    var webConfigurationFileMap = new WebConfigurationFileMap();
    
    webConfigurationFileMap.VirtualDirectories.Add(
        string.Empty,
        new VirtualDirectoryMapping(Directory.GetCurrentDirectory(), isAppRoot: true));
    
    var webConfig = WebConfigurationManager.OpenMappedWebConfiguration(
        webConfigurationFileMap,
        string.Empty);
