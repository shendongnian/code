    string MyConnString = string.Empty;
    SqlConnection MyConn = new SqlConnection(MyConnString);
    SqlCommand MyCmd = new SqlCommand("sp_MyStoredProcedure", MyConn);
    MyCmd.CommandType = CommandType.StoredProcedure;
    using(SqlDataReader dr = MyCmd.ExecuteReader(CommandBehavior.CloseConnection))
    {
      while(dr.Read())
      { 
         count = dr["cnt"];
         sum = dr["sum_ta"];
      }
      dr.NextResult();
      while(dr.Read())
      {
        // process MyTable row here
      }
    }
