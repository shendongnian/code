    string connString = 
        "Provider=Microsoft.ACE.OLEDB.12.0;data source=C:\\marcelo.accdb";
    
    DataTable results = new DataTable();
    
    using(OleDbConnection conn = new OleDbConnection(connString))
    {
        OleDbCommand cmd = new OleDbCommand("SELECT * FROM Clientes", conn);
    
        cmd.Open();
    
        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
    
        adapter.Fill(results);
    }
