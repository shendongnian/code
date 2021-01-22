        public static void ChangeDataSourcePassword(string dataSourcePath, string password)
        {
            using (ReportingService2005SoapClient reportingService = new ReportingService2005SoapClient())
            {
                reportingService.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                try
                {  
                    ServerInfoHeader serverInfo = null;
                    DataSourceDefinition dataSourceDefinition = null;
                    serverInfo = reportingService.GetDataSourceContents(dataSourcePath, out dataSourceDefinition);
                    dataSourceDefinition.Password = password;
                    serverInfo = reportingService.SetDataSourceContents(null, dataSourcePath, dataSourceDefinition);
                }
                catch (FaultException ex)
                {
                    // Do something with the exception. Rethrow it and/or show it to the user.
                    Console.WriteLine(string.Format("Failed to change the password on {0}: {1}", dataSourcePath, ex.Message));
                    throw new ApplicationException("Failed to change the password on the Data Source.", ex);
                }
            }
        }
