    public class Config
    {
        public string GetConnectionString()
        {
            Configuration config = null;
            var exeConfigPath = GetType().Assembly.Location;
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
            }
            catch (Exception ex)
            {
                //Error handling
            }
            if (config == null) return string.Empty;
            var myValue = GetAppSetting(config, "ConnectionString");
            return myValue;
        }
        private string GetAppSetting(Configuration config, string key)
        {
            var element = config.AppSettings.Settings[key];
            if (element == null) return string.Empty;
            var value = element.Value;
            return !string.IsNullOrEmpty(value) ? value : string.Empty;
        }
    }
