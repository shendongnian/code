    public LoginResult Login(string connectionString, string username, string password)
    {
        if (string.IsNullOrEmpty(username)
        {
            return LoginResult.InvalidUser;
        }
        else if (string.IsNullOrEmpty(password)
        {
            return LoginResult.InvalidPassword;
        }
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT password from USER where username=@username";
                command.Parameters.AddWithValue("@username", username);
                var actualPassword = (string)command.ExecuteScalar();
    
                if (actualPassword == null)
                {
                    return LoginResult.InvalidUser;
                }
                else if (password != actualPassword)
                {
                    return LoginResult.InvalidPassword;
                }
                else
                {
                    return LoginResult.Success;
                }
            }
        }
    }
    
    public enum LoginResult
    {
        Success,
        InvalidPassword,
        InvalidUser
    }
