    {
    Assembly __ServiceAssembly = Assembly.GetAssembly(typeof(MyServiceInstaller));
    Configuration config = ConfigurationManager.OpenExeConfiguration(__ServiceAssembly.Location);
    KeyValueConfigurationCollection  svcSettings = config.AppSettings.Settings;
    info("Service name : " + svcSettings["ServiceName"].Value);
    }
