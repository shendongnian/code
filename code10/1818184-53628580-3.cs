    private void ConfigureFromFile(ILoggerRepository targetRepository, FileInfo configFile)
    {
        if (m_configureAndWatch)
        {
            XmlConfigurator.ConfigureAndWatch(targetRepository, configFile);
        }
        else
        {
            XmlConfigurator.Configure(targetRepository, configFile);
        }
    }
    
    
