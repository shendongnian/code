    using (OracleConnection connection = GetConnection)
    {
      OracleCommand command = new OracleCommand("insert_into_pop");
      command.Connection = connection;
      command.CommandType = CommandType.StoredProcedure;
      command.ExecuteNonQuery();
    }
