    using (OleDBConnection conn = new OleDbConnection())
    {
      conn.ConnectionString = "Whatever connection string";
      using (OleDbCommand cmd = new OleDbCommand())
      {
        cmd.Connection = conn;
        cmd.CommandText = "Select * from CoolTable";
        using (OleDbDataReader dr = cmd.ExecuteReader())
        {
          while (dr.Read())
          {
            // do something like Console.WriteLine(dr["column name"] as String);
          }
        }
      }
    }
