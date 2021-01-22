    public static class ConfigurationManagerWrapper
    {
        public static NameValueCollection AppSettings
        {
            get { return ConfigurationManager.AppSettings; }
        }
        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get { return ConfigurationManager.ConnectionStrings; }
        }
        public static object GetSection(string sectionName)
        {
            return ConfigurationManager.GetSection(sectionName);
        }
        public static Configuration OpenExeConfiguration(string exePath)
        {
            return ConfigurationManager.OpenExeConfiguration(exePath);
        }
        public static Configuration OpenMachineConfiguration()
        {
            return ConfigurationManager.OpenMachineConfiguration();
        }
        public static Configuration OpenMappedExeConfiguration(ExeConfigurationFileMap fileMap, ConfigurationUserLevel userLevel)
        {
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, userLevel);
        }
        public static Configuration OpenMappedMachineConfiguration(ConfigurationFileMap fileMap)
        {
            return ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
        }
        public static void RefreshSection(string sectionName)
        {
            ConfigurationManager.RefreshSection(sectionName);
        }
    }
