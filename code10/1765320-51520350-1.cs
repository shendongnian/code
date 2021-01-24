    using (var conn = new SqlConnection("connection string here"))
    using (var command = new new SqlCommand(@"SELECT id, creationDate FROM invoice WHERE invoiceID = @invoiceID", conn))
    {
        command.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID;
        conn.Open();
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            temp.ID = (int)reader["id"];
            temp.InvoiceDate = (DateTime)reader["creationDate"];
        }
    }
