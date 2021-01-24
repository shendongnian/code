    List<int> integers = new List<int> { 1, 2, 3 };
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("n", typeof(int));
    dataTable.SetTypeName("integer_list_tbltype");
    foreach (int i in integers)
        dataTable.Rows.Add(i);
    using (SqlCommand cmd = new SqlCommand())
    {
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO YourTable (n) SELECT n FROM @integers";
        cmd.Parameters.Add("@integers", SqlDbType.Structured);
        cmd.Parameters["@integers"].Direction = ParameterDirection.Input;
        cmd.Parameters["@integers"].TypeName = "integer_list_tbltype";
        cmd.Parameters["@integers"].Value = dataTable;
        cmd.ExecuteNonQuery();
    }
