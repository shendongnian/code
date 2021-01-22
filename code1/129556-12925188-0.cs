    var builder = new SqlConnectionStringBuilder();
    
    builder.ApplicationName     = "My Demo App";
    builder.ConnectTimeout      = 5;
    builder.DataSource          = "(local)";
    builder.InitialCatalog      = "My Database";
    builder.IntegratedSecurity  = true;
    
    using(var connection = new SqlConnection(builder.ConnectionString))
    {
        Console.WriteLine("Connection Timeout: {0}", connection.ConnectionTimeout);
    }
