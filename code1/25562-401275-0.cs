    public class Utilities
    {
        static ConfigurationManager _configurationManager = new ConfigurationManager();
        public static ConfigurationManager ConfigurationManager
        {
            get
            {
                return _configurationManager;
            }
        }
    }
    public class ConfigurationManager
    {
        public object this[string value]
        {
            get
            {
                return new object();
            }
            set
            {
                // set something
            }
        }
    }
Now you can call Utilities.ConfigurationManager["someKey"] using indexer notation.
