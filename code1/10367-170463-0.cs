    using (SqlConnection conn = new SqlConnection(connection))
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(query, conn);
        adapter.Fill(dataset);
        return dataset;
    }
