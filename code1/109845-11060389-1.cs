        public static void CreateConnectionString(string datasource, string initialCatalog, string userId, string password)
        {
            try
            {
                //Integrated security will be off if either UserID or Password is supplied
                var integratedSecurity = string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password);
 
                //Create the connection string using the connection builder
                var connectionBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = datasource,
                    InitialCatalog = initialCatalog,
                    UserID = userId,
                    Password = password,
                    IntegratedSecurity = integratedSecurity
                };
                //Open the app.config for modification
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //Retreive connection string setting
                var connectionString = config.ConnectionStrings.ConnectionStrings["ConnectionStringName"];
                if (connectionString == null)
                {
                    //Create connection string if it doesn't exist
                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings
                    {
                        Name = ConnectionName,
                        ConnectionString = connectionBuilder.ConnectionString,
                        ProviderName = "System.Data.SqlClient" //Depends on the provider, this is for SQL Server
                    });
                }
                else
                {
                    //Only modify the connection string if it does exist
                    connectionString.ConnectionString = connectionBuilder.ConnectionString;
                }
                //Save changes in the app.config
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception)
            {
                //TODO: Handle exception
            }
    }
