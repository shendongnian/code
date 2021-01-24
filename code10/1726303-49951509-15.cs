    protected Boolean checkUser(string email, string password)
    {
    	SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AppConnectionString"].ConnectionString);
    	//define sql query
    	connection.Open();
    	string query = "SELECT Admin FROM Users WHERE [Admin] = 1 and [Email] = @email AND [Password] = @password";
    
    	DataTable dt = new DataTable();
    	SqlCommand command = new SqlCommand(query, connection);
    	command.Parameters.AddWithValue("@email", email);
    	command.Parameters.AddWithValue("@password", password);
    
    	using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    	{
    		adapter.Fill(dt);
    		if (dt.Rows.Count > 0)
    		{
    			return true;
    		}
    	} 
    
    
    	connection.Close();
    
    	return false;
    }
