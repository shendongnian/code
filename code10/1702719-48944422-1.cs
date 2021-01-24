    string myQuery = "select count(*) from signup where [username]=@userName and  [passwd]= @password";
	string connectionString='';//your connection string
	using (SqlConnection conn = new SqlConnection(connectionString))
	{
		using (SqlCommand cmd = new SqlCommand(myQuery , conn))
		{        
			connection.Open();
			cmd.Parameters.Add(new SqlParameter("userName", txtusername.Text));
			cmd.Parameters.Add(new SqlParameter("password", txtpasswd.Text));
			cmd.ExecuteNonQuery();
		}
	}
