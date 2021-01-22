        public class ConfigurationManager 
    {
        public ConfigurationManager()
        {
            // TODO: Complete member initialization
        }
        public object this[string keyName]
        {
            get
            {
                    return ConfigurationManagerItems[keyName];
            }
            set
            {
                    ConfigurationManagerItems[keyName] = value;
            }
        }
        private static Dictionary<string, object> ConfigurationManagerItems = new Dictionary<string, object>();        
    }
