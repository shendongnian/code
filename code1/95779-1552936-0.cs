    int lastId = 0;
    using(SqlConnection Connection = new SqlConnection("(connection string)"))
    {
      string queryStatement = 
        "INSERT INTO dbo.Policies(fields) OUTPUT Inserted.LastID VALUES(....)";
    
      using(SqlCommand Command = new SqlCommand(queryStatement, Connection))
      {
         Connection.Open();
         lastId = Command.ExecuteScalar();
         Connection.Close();
      }
    }
