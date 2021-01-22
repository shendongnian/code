      var connectionString = new SqlConnectionStringBuilder(connectionString);
      var serverConnection = new ServerConnection("DatabaseInstanceName in server");
      var serverInstance = new Server(serverConnection);
      if (serverInstance.Databases.Contains(connectionString.InitialCatalog))
          serverInstance.KillDatabase(connectionString.InitialCatalog);
      var db = new Database(serverInstance, connectionString.InitialCatalog);
      try
      {
         db.Create();
      }
      catch (SqlException ex)
      {
         throw;
      }
