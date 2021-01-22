    internal string ConnectionString
    {
        get
        {
            return getConnectionStringByServerName(this.HttpContext.Request.ServerVariables["SERVER_NAME"]);
        }
    }
    
    internal string getConnectionStringByServerName(string serverName)
    {
        if (serverName.Equals("localhost"))
        {
            return WebConfigurationManager.ConnectionStrings["DevelopmentDB"].ConnectionString;
        }
        else
        {
            return WebConfigurationManager.ConnectionStrings["ProductionDB"].ConnectionString;
        }
    }
