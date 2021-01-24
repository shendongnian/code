    System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
    if (config.ConnectionStrings.ConnectionStrings.Count > 0)
    {
        var connString = config.ConnectionStrings.ConnectionStrings[nameOfConnectionString].ToString();
        return connString;
    }
