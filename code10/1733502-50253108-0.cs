    ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
    
    if (connections.Count != 0)
    {
        foreach (ConnectionStringSettings connection in connections)
        {
           string conString = ConfigurationManager.ConnectionStrings[connection.Name].ConnectionString;
           Configuration config =  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           config.ConnectionStrings.ConnectionStrings[connection.Name].ConnectionString = EncryptConfig(conString); //just call your Encryption part here instead of "EncryptConfig()" 
           config.Save(ConfigurationSaveMode.Modified, true);
           ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
