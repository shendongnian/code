    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    string sql = "Select * From Users Where UserID=@user And Password=@pwd";
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
    	command.Parameters.Add("@user", SqlDbType.VarChar);
    	command.Parameters["@user"].Value = "value";
    	command.Parameters.Add("@pwd", SqlDbType.VarChar);
    	command.Parameters["@pwd"].Value = "value";
    	connection.Open();
    	using (SqlDataReader reader = command.ExecuteReader())
    	{
    		if (reader.HasRows)
    		{
    			// read row
    		}
    	}
    }
