    public class ProviderConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("Providers",IsRequired = true)]
        public ProviderElementCollection Providers
        {
            get{ return (ProviderElementCollection)this["Providers"]; }
            set{ this["Providers"] = value; }
        }
    }
