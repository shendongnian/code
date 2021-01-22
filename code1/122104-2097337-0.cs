    OleDbConnection objConnection = new OleDbConnection();
    string strSQL = "SELECT * FROM [YourTable]";
    objConnection = new OleDbConnection(connectionString);
    objConnection.Open();
    OleDbCommand cmd = new OleDbCommand(strSQL, objConnection);
    DataTable dt = new DataTable();
    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
    da.Fill(dt);
