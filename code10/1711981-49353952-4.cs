    void DoStuffWithDataTable(string query, Action<DataTable> action, params SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
        using (var table = new DataTable())
        {
            foreach(var param in parameters)
            {
                command.Parameters.Add(param);
            }
            // SqlDataAdapter has a fill overload that only needs a data table
            adapter.Fill(table);
            action();
            adapter.Update(table);
        }
    }
