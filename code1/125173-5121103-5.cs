    // create my source DataTable
    object [] row1 = {1, "a"};
    object [] row2 = {2, "b"};
    var myDataTable = new DataTable();
    myDataTable.Columns.Add(new DataColumn("foo"));
    myDataTable.Columns.Add(new DataColumn("bar"));
    myDataTable.LoadDataRow(row1, true);
    myDataTable.LoadDataRow(row2, true);
    
    // bulk send data to database
    var conn = new SqlConnection(connectionString);
    var cmd = new SqlCommand("uspInsertMyBulkData", conn)
        {
            CommandType = CommandType.StoredProcedure
        };
    SqlParameter param = cmd.Parameters.AddWithValue("@myTable", myDataTable);
    param.SqlDbType = SqlDbType.Structured;
    cmd.ExecuteNonQuery();
