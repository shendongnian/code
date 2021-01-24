    private void RichTextBoxSearch_TextChanged(object sender, EventArgs e)
    {
        using (var conn = new SqlConnection())
        {
            conn.ConnectionString = @"...";
            conn.Open();
            // Note the @search parameter.
            using (var adapter = new SqlDataAdapter(
                "SELECT ... FROM TBLMat where MAT like @search", conn))
            {
                // Use the type of SqlDbType that you have in the database table
                adapter.SelectCommand.Parameters.Add("search", SqlDbType.NVarChar).Value =
                    "%" + richTextBoxSearch.Text + "%";
                adapter.Fill(dataTable); // note that the dataTable is NOT a local variable
                if (dataTable.Columns.Count > 0)
                {
                    // It is assumed that Columns[0] contains unique values
                    dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
                }
                mainAMSDataGrid.DataSource = dataTable;
                mainAMSDataGrid.Visible = true;
            }
        }
    }
