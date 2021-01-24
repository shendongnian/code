    DataTable tbl = new DataTable();
    using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
    		$"Data Source={path};" +
    		@"Extended Properties=""Excel 12.0;HDR=No"""))
    using (OleDbCommand cmd = new OleDbCommand(@"Select * from [Engineering BOM$A1:i13000]", con))
    {
    	con.Open();
    	tbl.Load(cmd.ExecuteReader());
    }
