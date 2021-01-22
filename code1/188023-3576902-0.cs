    public static class Settings
    {
        public static System.Configuration.Configuration Configuration { get; private set; }
        static Settings()
        {
            // load a .config file for this assembly
            var assembly = typeof(Settings).Assembly;
            Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(assembly.Location);
            if (Configuration == null)
                throw new System.Configuration.ConfigurationErrorsException(string.Format("Unable to load application configuration file for the assembly {0} at location {1}.", assembly.FullName, assembly.Location));
        }
        // This function is only provided to simplify access to appSettings in the config file, similar to the static System.Configuration.ConfigurationManager.AppSettings property
        public static string GetAppSettingValue(string key)
        {
            // attempt to retrieve an appSetting value from this assembly's config file
            var setting = Configuration.AppSettings.Settings[key];
            if (setting != null)
                return setting.Value;
            else
                return null;
        }
    }
