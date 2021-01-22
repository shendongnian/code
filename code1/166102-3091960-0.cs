    public class DevModeSetting : ConfigurationSection
    {
        public override bool IsReadOnly()
        {
            return false;
        }
        [ConfigurationProperty("webServiceUrl", IsRequired = false)]
        public string WebServiceUrl
        {
            get
            {
                return (string)this["webServiceUrl"];
            }
            set
            {
                this["webServiceUrl"] = value;
            }
        }
    }
