    private void button1_Click(object sender, EventArgs e)
    {
    
        var ds = new DataSet();
        var dt1 = GetTable1Data();
        var dt2 = GetTable2Data();
        
        ds.Tables.Add(dt1);
        ds.Tables.Add(dt2);
    
        ds.Relations.Add("RelationTable",
           ds.Tables["Table1"].Columns["col1"],
           ds.Tables["Table2"].Columns["col1"]);
    
        gridControl1.DataSource = ds.Tables["Table1"];
        gridControl1.RefreshDataSource();
    }
    
    private DataTable GetTable1Data()
    {
        using (var conn = new SqlConnection("Conneciton string goes here"))
        {
            conn.Open();
            using (var cmd = new SqlCommand("Stored procedure name goes here", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }
    }
    
    private DataTable GetTable2Data()
    {
        using (var conn = new SqlConnection("Conneciton string goes here"))
        {
            conn.Open();
            const string sql = "SELECT * FROM Table2";
            using (var cmd = new SqlCommand(sql, conn))
            {
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }
    }
