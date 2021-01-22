    OleDbConnection conn;
    OleDbCommand comm;
    OleDbDataReader dr;
    conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\db1.mdb");
    comm = new OleDbCommand("Select * from Table1",conn);
    conn.Open();
    dr = comm.ExecuteReader();
    conn.Close();
