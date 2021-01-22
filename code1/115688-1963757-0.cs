    SqlConnection conn = new SqlConnection(connString);
    conn.Open();
    
    SqlCommand cmd = new SqlCommand(sql, conn);
    SqlDataReader rdr = cmd.ExecuteReader();
    
    DataTable schema = rdr.GetSchemaTable();
    foreach (DataRow row in schema.Rows) 
    {
    	foreach (DataColumn col in schema.Columns)
    		Console.WriteLine(col.ColumnName + " = " + row[col]);
    }
    rdr.Close()
    conn.Close();
