        string query = "SELECT * FROM users WHERE username = @username";
        ServerModel.Database.CheckConnection(); // Get the main connection
        MySqlCommand cmd = new MySqlCommand(query, ServerModel.Database);
        cmd.Parameters.AddWithValue("@username", username);
    
        UserStatus userStatus;
    
        MySqlDataReader dataReader = cmd.ExecuteReader()
        if (dataReader.Read())
            {
                ...
                dataReader.Close();
                return userStatus;
            }
