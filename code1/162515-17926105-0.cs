    private IEnumerable<string> getAllTables()
    {
      var sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
      var serverConnection = new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConnection);
      var server = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);
      var database = server.Databases[databaseName];
      foreach (Microsoft.SqlServer.Management.Smo.Table table in database.Tables)
      {
        yield return table.Name;
      }
    }
