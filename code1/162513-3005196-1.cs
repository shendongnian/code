    string[] GetAllTables(SqlConnection connection)
    {
      List<string> result = new List<string>();
      SqlCommand cmd = new SqlCommand("SELECT name FROM sys.Tables", connection);
      System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
      while(reader.Read())
       result.Add(reader["name"].ToString());
      return result.ToArray();
    }
