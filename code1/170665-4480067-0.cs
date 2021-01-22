    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        connection.Open();
        using (DataSet ds = new DataSet())
        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        {
            adapter.Fill(ds);
        }
    }
