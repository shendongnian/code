    {
    Assembly __ServiceAssembly = Assembly.GetAssembly(typeof(SyslogServiceInstaller));
    ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
    configFileMap.ExeConfigFilename = 
         Path.Combine(Directory.GetParent(__ServiceAssembly.Location).ToString(),
         "App.config");
    
    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(
         configFileMap, ConfigurationUserLevel.None);
    KeyValueConfigurationCollection mySettings = config.AppSettings.Settings;
    Console.Out.WriteLine(mySettings["ServiceName"].Value);
    }
