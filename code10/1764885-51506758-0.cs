	using (var connection = new SqlConnection(Cnn.ConnectionString)) // use same connection string as your Global instance
	using (var cmd = connection.CreateCommand())
	{
	  cmd.CommandType = CommandType.Text;
	  cmd.CommandText = "SELECT * FROM tblNummering WHERE type = 1 AND EindPer IS NULL;"
	  connection.Open();
	  using(SqlDataReader reader = cmd.ExecuteReader())
	  {
	    while(reader.Read())
		{
		  // fetch results
		}
	  }
	}
