    DataTable result = new DataTable();
    using (SqlConnection conn = new SqlConnection(ConnectionString))
     {
       SqlDataAdapter adapter = new SqlDataAdapter("StoredProcedureName", conn);
       adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
       adapter.SelectCommand.Parameters.Add("@subid",SqlDbType.Int).Value= comboBox1.SelectedValue;
       adapter.SelectedCommand.Parameters.Add("@classid",SqlDbType.Int).Value=comboBox1.SelectedValue;
       adapter.Fill(result);
     }
     dataGridView1.DataSource = result;
