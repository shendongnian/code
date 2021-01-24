    class ConfigTableAttribute : TableAttribute {
        public ConfigTableAttribute(string configSetting)
             : base(LookupTableNameFromConfig(configSetting));
        private static string LookupTableNameFromConfig(string configSetting)
        {
            // TODO: your code here
        }
    }
