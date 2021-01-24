    ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
    
    if (connections.Count != 0)
    {
        //go trough all available ConnectionStrings in app.config
        foreach (ConnectionStringSettings connection in connections)
        {
           //reading the ConnectionString
           string conString = ConfigurationManager.ConnectionStrings[connection.Name].ConnectionString;
           
           //writing the ConnectionString
           Configuration config =  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           config.ConnectionStrings.ConnectionStrings[connection.Name].ConnectionString = EncryptConfig(conString); //just call your Encryption part here instead of "EncryptConfig()" 
           config.Save(ConfigurationSaveMode.Modified, true);
           ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
