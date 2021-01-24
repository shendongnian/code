     private SqlConnection Connection;
     public bool Open()
     {
        try
        {
           ConnectionString = "your connection string";
           Connection = new SqlConnection(ConnectionString);
           Connection.Open();
           return true;
         }
         catch (Exception ex)
         {
            errorMessage = ex.Message;
            return false;
         }
     }
     public bool RunQuery(string ProcedureName, SqlParameter[] Parameters)
     {
         bool res = false;
         try
         {
             SqlCommand Command = new SqlCommand();
             Command.CommandText = ProcedureName;
             Command.CommandType = CommandType.StoredProcedure;
             Command.Connection = Connection;
             Command.Parameters.AddRange(Parameters);
             Command.ExecuteNonQuery();
             res = true;
          }
          catch (Exception ex)
          {
             throw ex;
          }
          return res;
      }
