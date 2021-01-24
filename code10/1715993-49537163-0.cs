    [System.AttributeUsage(System.AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    sealed class ConfigurationLocationAttribute : System.Attribute
    {
        public string ConfigurationLocation { get; }
        public ConfigurationLocationAttribute(string configurationLocation)
        {
            this.ConfigurationLocation = configurationLocation;
        }
    }
