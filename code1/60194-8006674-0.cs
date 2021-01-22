    GenericConnection connection = new GenericConnection();
    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                                                                        
    file.DirectoryName + "\"; Extended Properties='text;HDR=Yes;FMT=" + strDelimiter + "(,)';");
    connection.DBConn = con;
    connection.Filename = strFilePath;
        
    FileInfo file = new FileInfo(conn.Filename);
            
    DataTable dt = new DataTable();
            
    string selectFields = "Name, email";
            
    using (OleDbCommand cmd = new OleDbCommand(string.Format("SELECT {0} FROM [{1}]", selectFields, file.Name), (OleDbConnection)conn.DBConn))
    {
        conn.DBConn.Open();
        using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
        {
           adp.Fill(dt);
        }
    }
