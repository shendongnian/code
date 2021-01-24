    protected Boolean checkUser(string email, string password)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AppConnectionString"].ConnectionString);
        //define sql query
        connection.Open();
        string query = "SELECT Admin FROM Users WHERE [Admin] = 'True' and [Email] = @email AND [Password] = @password";
    
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@password", password);
    
        var result = command.ExecuteScalar() as string;
    
        if (result!=null && "true" == Admin.ToString().ToLower())
        {
            return true;
        }
    	
        connection.Close();
    
        return false;
    }
