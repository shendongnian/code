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
        command.Parameters.Add(GetParameter(dbFactory, "@artist", song[i].artist));
        command.Parameters.Add(GetParameter(dbFactory, "@title", song[i].title));
        command.Parameters.Add(GetParameter(dbFactory, "@genre", song[i].genre));
        using (DbDataReader reader = command.ExecuteReader())
        {
            // do work
        }
    }
