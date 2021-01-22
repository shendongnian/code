    private void changeConnectionSettings(ConnectionProperties cp)
    {
         var cnSection = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
         String connString = cnSection.ConnectionStrings.ConnectionStrings[cp.Name].ConnectionString;
         connString = changeConnStringItem(connString, "provider connection string=\"data source", cp.DataSource);
         connString = changeConnStringItem(connString, "provider connection string=\"server", cp.DataSource);
         connString = changeConnStringItem(connString, "user id", cp.Username);
         connString = changeConnStringItem(connString, "password", cp.Password);
         connString = changeConnStringItem(connString, "initial catalog", cp.InitCatalogue);
         connString = changeConnStringItem(connString, "database", cp.InitCatalogue);
               cnSection.ConnectionStrings.ConnectionStrings[cp.Name].ConnectionString = connString;
         cnSection.Save();
         ConfigurationManager.RefreshSection("connectionStrings");
    }
