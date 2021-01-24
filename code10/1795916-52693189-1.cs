    public User GetUser(string login)
    {
    	User user = new User();
    	const string sql = "SELECT * FROM BookMenagerDB.dbo.users";
    	using (SqlConnection connection = new SqlConnection(DataBaseUtility.ConnectionString))
    	using (SqlCommand command = new SqlCommand(sql, connection))
    	{
    		connection.Open();
    		command.Parameters.AddWithValue("@login", login);
    		using (SqlDataReader reader = command.ExecuteReader())
    		{
    			if (reader.Read())
    			{
    				user.Id = (int)reader["UserId"];
    				user.Login = reader["UserLogin"].ToString();
    				user.PasswordHash = reader["UserPassword"].ToString();
    				user.Salt = (byte[])reader["UserPasswordSalt"];
    			}
    		}
    	}
    	return user;
    }
