    var connectionSettings = ConfigurationManager.ConnectionStrings["Example"];
    var dbFactory = DbProviderFactories.GetFactory(connectionSettings.ProviderName);
    using (DbConnection connection = dbFactory.CreateConnection())
    using (DbCommand command = connection.CreateCommand())
    {
        string sql = @"
    SELECT * 
    FROM database.tablename 
    WHERE artist=@artist AND title=@title 
      AND genre=@genre";
        command.CommandText = sql;
        command.Parameters.Add(GetParameter(dbFactory, "@artist", null));
        command.Parameters.Add(GetParameter(dbFactory, "@title", null));
        command.Parameters.Add(GetParameter(dbFactory, "@genre", null));
        using (DbDataReader reader = command.ExecuteReader())
        {
            // do work
        }
    }
