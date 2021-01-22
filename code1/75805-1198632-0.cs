    using(SqlConnection connection =
        new SqlConnection(connectionString))
    {
    connection.Open();
    DataTable dt = connection.GetSchema();
    connection.Close();
    }
