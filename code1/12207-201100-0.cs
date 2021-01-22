    public void InsertUser(IEnumerabler<string> userCodes)
    {
       using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
       {
          sqlConnection.Open();
          SqlTransaction transaction = connection.BeginTransaction();
          SqlCommand sqlCommand = new SqlCommand("InsertUser", sqlConnection);
          sqlCommand.Transaction = transaction;
          sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
          SqlParameter param = sqlCommand.Parameters.Add("@UserCode", SqlDbTypes.VarChar);
          
          foreach(string code in userCodes)
          {
              param.Value = code;
              sqlCommand.ExecuteNonQuery();
          }      
          transaction.Commit();
       }
    }
