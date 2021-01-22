    Dictionary<int, string> users = new Dictionary<int, string>();
    using(SqlConnection connection = new SqlConnection("Your connection string"))
    {
        string query = "SELECT UserId, UserName FROM Users";
        SqlCommand command = new SqlCommand(query, connection);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
                users.Add(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
        }
        connection.Close();
    }
