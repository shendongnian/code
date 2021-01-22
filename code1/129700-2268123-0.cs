    using (SqlConnection connection = new SqlConnection(connectionString))
    {
       connection.Open();
       // Do work here; connection closed on following line.
    }
