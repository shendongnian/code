    public class Utilities
    {
        private static ConfigurationManager _configurationManager = new ConfigurationManager();
        public static ConfigurationManager ConfigurationManager => _configurationManager;
    }
    public class ConfigurationManager
    {
        public object this[string value]
        {
            get => new object();
            set => // set something
        }
    }
Now you can call Utilities.ConfigurationManager["someKey"] using indexer notation.
