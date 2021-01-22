    DataTable dataTable = new DataTable();
    
    using (SqlConnection connection = new SqlConnection(yourConnectionString))
    {
        connection.Open();
        
        using (SqlDataAdapter adapter = new SqlDataAdapter(yourQuery, connection))
        {        
            adapter.Fill(dataTable);
        }
    }
