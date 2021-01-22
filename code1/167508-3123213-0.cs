    using (var command = new SqlCommand("dbo.CheckUsername11", conn) 
                { CommandType = CommandType.StoredProcedure })
    {
      command.Parameters.Add(new SqlParameter("@result") { ParameterDirection.ReturnValue });
      command.Parameters.AddWithValue("@Username", username);
      
      command.ExecuteNonQuery();
      
      return (int)command.Parameters["@result"].Value;
    }
