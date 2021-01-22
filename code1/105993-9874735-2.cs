    private void SavePluginSettings(List<IExposedProperties> PluginProperties) {
        //  Feel free to get fancy with LINQ here
        foreach (IExposedProperties pluginProperties in PluginProperties) {
            
            foreach (KeyValuePair<string,string> Property in pluginProperties.GetProperties()) {
                
                //  Use Property.Key to write to the config file, and Property.Value
                //  as the value to write.
                //
                //  Note that you will need to avoid Key conflict... you can prepend
                //  the plugin name to the key to avoid this
                
            } 
        }
    }
