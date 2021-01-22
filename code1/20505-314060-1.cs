            /// <summary>
            /// First remove the old connectionstring and after that
            /// add a connection string to the connectionstrings
            /// section and store it in the configuration file. 
            /// </summary>
            /// <param name="csName">The name of the property.</param>
            /// <param name="connectionString">The connectionstring as specified.</param>
            public static void UpdateConnectionStrings(string csName, string connectionString)
            {
                // Get the configuration file
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);
    
                // Remove the existing connectionstring.
                config.ConnectionStrings.ConnectionStrings.Remove(csName);
                // Add the connectionstring
                ConnectionStringsSection csSection = config.ConnectionStrings;
                csSection.ConnectionStrings.Add(
                    new ConnectionStringSettings(csName, 
                    connectionString, "System.Data.SqlClient"));
    
                // Save the configuration file
                config.Save(ConfigurationSaveMode.Full);
            }
