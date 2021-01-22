    public void InsertUser(IEnumerabler<string> userCodes)
    {
       using (SqlConnection sqlConnection = new SqlConnection(this.connectionString), 
                 SqlCommand sqlCommand = new SqlCommand("InsertUser", sqlConnection))
       {
          sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
          SqlParameter param = sqlCommand.Parameters.Add("@UserCode", SqlDbTypes.VarChar);
          sqlConnection.Open();
          foreach(string code in userCodes)
          {
              param.Value = code;
              sqlCommand.ExecuteNonQuery();///0.2 seconds
          }
       }
    }
