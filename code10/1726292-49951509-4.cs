    protected Boolean checkUser(string email, string password)
    {
    	SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AppConnectionString"].ConnectionString);
    	//define sql query
    	connection.Open();
    	string query = "SELECT Admin FROM Users WHERE [Admin] = 'True' and [Email] = @email AND [Password] = @password";
    
    	SqlCommand command = new SqlCommand(query, connection);
    	command.Parameters.AddWithValue("@email", email);
    	command.Parameters.AddWithValue("@password", password);
    	
    	String Admin = command.ExecuteScalar().ToString();
    
    	if (Admin == "True")
    	{
    		return true;
    	}
    	connection.Close();
    
    	return false;
    }
