    foreach(ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
    {
       string name = css.Name;
       string connString = css.ConnectionString;
       string provider = css.ProviderName;
    }
