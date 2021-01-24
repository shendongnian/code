    public bool isUsernameAvailable(string uName)
    {
        string sql = "SELECT Username FROM Users WHERE Username= @user";
        string connString = ConnectionString.GetConnection();
        using (SqlConnection connection = new SqlConnection(connString))
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            var uNameParam = new SqlParameter("user", SqlDbType.String);
            uNameParam.Value = uName;
            command.Parameters.Add(uNameParam);
            var exists = command.ExecuteScalar();
            if (exists != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
