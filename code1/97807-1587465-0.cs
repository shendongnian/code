    using (DbConnection connection = factory.CreateConnection())
    {
      connection.ConnectionString = connectString;
      using (DbCommand command = connection.CreateCommand())
      {
        connection.Open();
