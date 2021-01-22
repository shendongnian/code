    public static string ConnectionString
    {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["YourConnectionStringName "].ConnectionString = value;
                config.Save(ConfigurationSaveMode.Minimal, true);
                //refresh so that you can use the updates value directly without the need to restart the application
                System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
            }
        }
