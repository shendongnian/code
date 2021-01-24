    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    string sql = "Select * From Users Where UserID=@user And Password=@pwd";
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
    	command.Parameters.AddWithValue("@user", "value");
    	command.Parameters.AddWithValue("@pwd", "value");
    	connection.Open();
    	using (SqlDataReader reader = command.ExecuteReader())
    	{
    		if (reader.HasRows)
    		{
    			// read row
    		}
    	}
    }
