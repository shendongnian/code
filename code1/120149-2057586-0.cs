    public void SignUpControllerDay()
    {
        using (var conn = new SqlConnection(ConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT ...";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var phone = reader["Phone_Number"].ToString();
                    Bar(phone);
                }
            }
        }
    }
    public void Bar(string phone)
    {
        using (var conn = new SqlConnection(ConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT ..."; // use phone to prepare statement
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Fill the grid
                }
            }
        }
    }
