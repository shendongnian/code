    using (SqlConnection connection = new SqlConnection(connectionString),
           SqlCommand command = new SqlCommand(query, connection),
           SqlDataAdapter adapter = new SqlDataAdapter(command),
           SqlCommandBuilder builder = new SqlCommandBuilder(adapter),
           DataSet dataset = new DataSet())
    {
