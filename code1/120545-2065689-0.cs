    var dbProviderFactory = DbProviderFactories.GetFactory(ConnectionStringSettings.ProviderName);
    conn = dbProviderFactory .CreateConnection();
    conn.ConnectionString = ...
    conn.Open();
    string serverVersion = conn.ServerVersion;
