            /// <summary>
            /// Add a connection string to the connection
            /// strings section and store it in the
            /// configuration file. 
            /// </summary>
            /// <param name="csName">The name of the property.</param>
            /// <param name="connectionString">The connectionstring as specified.</param>
            public static void AddConnectionStrings(string csName, string connectionString)
            {
    
                // Get the configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);
    
                // Add the connection string.
                ConnectionStringsSection csSection = config.ConnectionStrings;
                csSection.ConnectionStrings.Add(
                    new ConnectionStringSettings(csName,
                        connectionString, "System.Data.SqlClient"));
    
                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Full);       
            }
   
    
