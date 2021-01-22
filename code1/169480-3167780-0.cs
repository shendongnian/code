    // Back up the existing connection string
    ConnectionStringSettings connStringSettings = ConfigurationManager.ConnectionStrings[connectionName];
    string oldConnectionString = connStringSettings.ConnectionString;
    
    // Override the IsReadOnly method on the ConnectionStringsSection.
    // This is something of a hack, but will work as long as Microsoft doesn't change the
    // internals of the ConfigurationElement class.
    FieldInfo fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
    fi.SetValue(connStringSettings, false);
    
    // Set the new connection string value
    connStringSettings.ConnectionString = connectionStringNeededForNUnitTest;
