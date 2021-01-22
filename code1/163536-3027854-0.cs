    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            connection.Open();
            int tenderId = (int)(decimal)command.ExecuteScalar();
        }
    }
