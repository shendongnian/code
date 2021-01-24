    private void UpdateDataGrid(DataGridView grid, string sql)
    {
        using (var connection = SQLConnection.GetConnection())
        using (var command = new SqlCommand(sql, connection))
        using (var adapter = new SqlDataAdapter())
        {
            adapter.SelectCommand = command;
            dbdataset = new DataTable();
            adapter.Fill(dbdataset);
            grid.DataSource = new BindingSource { DataSource = dbdataset };
            adapter.Update(dbdataset);
        }
    }
