    public class Provider : ConfigurationElement
    {
        [ConfigurationProperty("Key",IsRequired = true, IsKey = true)]
        public string Key
        {
            get { return (string) this["Key"]; }
            set { this["Key"] = value; }
        }
        [ConfigurationProperty("Queries", IsRequired = true)]
        public KeyValueConfigurationCollection Queries
        {
            get { return (KeyValueConfigurationCollection)this["Queries"]; }
            set { this["Queries"] = value; }
        }
    }
