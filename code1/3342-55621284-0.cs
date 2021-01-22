    using (var connection = new SqlConnection(connectionString))
    {
      var server = new Server(new ServerConnection(connection));
      server.ConnectionContext.ExecuteNonQuery(sql);
    }
