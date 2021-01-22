    public static User GetUser(string username)
    {
        using (var connection = new SqlConnection(ConnectionString))
        using (var command = connection.CreateCommand())
        {
            connection.Open();
            command.CommandText = "select name, username from users where username = @username";
            command.Parameters.AddWithValue("@username", username);
            using (var reader = command.ExecuteReader()) 
            {
                while (reader.Read())
                {
                    return new User 
                    {
                        Username = username,
                        Name = reader.GetString(0),
                    }
                }
            }
            return null;
        }
    }
