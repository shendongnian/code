    using (OracleConnection connection = GetConnection)
    {
      OracleCommand command = new OracleCommand("insert_into_pop");
      command.Connection = connection;
      command.CommandType = CommandType.StoredProcedure;
      command.Parameters.AddWithValue("@Param", value);  // 0 or more parameters passed in here
      command.ExecuteNonQuery();
    }
