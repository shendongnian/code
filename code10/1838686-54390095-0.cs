    using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand("myproc", connection) {  CommandType = CommandType.StoredProcedure })
    using (var dataAdapter = new SqlDataAdapter(command))
    {
        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        dataAdapter.Fill(dataSet);
    }
