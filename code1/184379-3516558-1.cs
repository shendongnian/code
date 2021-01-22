        [ConfigurationProperty("", IsDefaultCollection = true)]
        public PluginCollection Plugins
        {
            get
            {
                PluginCollection subList = base[""] as PluginCollection;
                return subList;
            }
        }
