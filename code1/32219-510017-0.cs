    using System.Data.OleDb;
    DataTable dt = new DataTable();
    string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\Book1.xls;Extended Properties='Excel 8.0;HDR=NO'";
    using (OleDbConnection conn = new OleDbConnection(connString))
    {
        conn.Open();                
        //Where [F1] = column one, [F2] = column two etc, etc.
        OleDbCommand selectCommand = new OleDbCommand("select [F1] AS [id] from [Sheet1$]",conn);
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = selectCommand;
        adapter.Fill(dt);
    }
    
    listBox1.DataSource = dt;
    listBox1.DisplayMember = "id";
