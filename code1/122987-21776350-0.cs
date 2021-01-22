    private void processConfigurationFile()
    {
        // Load and process the configuration file
        // which happens to be an xml file.
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(configurationPath);
        
        // This method is abstract which will force
        // the inherited class to override it.
        processConfigurationFile(xmlDoc);
    }
    
    protected abstract void processConfigurationFile(XmlDocument document);
