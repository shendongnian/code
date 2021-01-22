    var configMap = 
        new ExeConfigurationFileMap
        {
            ExeConfigFilename = externalConfigurationFile
        };
    System.Configuration.Configuration externalConfiguration =
        ConfigurationManager.OpenMappedExeConfiguration(
            configMap,
            ConfigurationUserLevel.None);
    
    foreach (var setting in externalConfiguration.AppSettings.Settings)
    {
        ...
    }
    
    externalConfiguration.Save(ConfigurationSaveMode.Full);
