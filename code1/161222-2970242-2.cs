    public bool UserNameExists()
    {
      int result = int.MinValue;
    
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "SELECT COUNT(*) FROM Policia WHERE NumeroPlaca = @username AND Password = @password";
        command.Parameters.Clear();
        command.Parameters.Add("@username", SqlDbType.VarChar).Value = Session.Contents["username"];
    	command.Parameters.Add("@password", SqlDbType.VarChar).Value = Session.Contents["password"];
        result = Convert.ToInt32(command.ExecuteScalar());
      }
    
      if (result > 0)
      {
        return true;
      }
      {
        return false;
      }
    }
