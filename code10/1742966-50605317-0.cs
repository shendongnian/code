        static void Main(string[] args)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            KeyValueConfigurationCollection settings = configuration.AppSettings.Settings;
            settings.Add("Port", "12");
            configuration.Save(ConfigurationSaveMode.Modified);
        }
    }`
