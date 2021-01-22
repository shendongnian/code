    OleDbConnection conn = new OleDbConnection(
        "Data Source=(local);Initial Catalog=Search.CollatorDSO;Integrated Security=SSPI;User ID=<username>;Password=<password>");
    
    OleDbDataReader rdr = null;
    
    conn.Open();
    
    OleDbCommand cmd = new OleDbCommand("SELECT Top 5 System.ItemPathDisplay FROM SYSTEMINDEX", conn);
    
    rdr = cmd.ExecuteReader();
    
    while (rdr.Read())
    {
        Console.WriteLine(rdr[0]);
    }
    
    rdr.Close();
    conn.Close();
