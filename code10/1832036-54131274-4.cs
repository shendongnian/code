    public DataSet CreateTable()
    {
        using(var conn = new SqlConnection(Oconnection))
        {
           conn.Open();
           using(var command = new SqlCommand())
           {
              command.Connection = conn;
              command.CommandTimeout = 120; // higher if needed
              command.CommandType = CommandType.StoredProcedure;
              command.CommandText = "usp_CreateTables";
              var da = new SqlDataAdapter();
              da.SelectCommand = command;
              var ds = new DataSet();
              da.Fill(ds);
              return ds;
          }
       }
    }
