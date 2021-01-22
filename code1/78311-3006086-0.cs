    var conn = new OleDbConnection(connectionString);
     var ds = new DataSet();
                    var adapter = new OleDbDataAdapter("SELECT Column1 FROM Table1", conn);
                    conn.Open();
                    adapter.Fill(ds);
                    conn.Close();
    var value = ds.Tables[0].Rows[0]["Column1"].ToString();
