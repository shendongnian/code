    OleDbConnection SQLConn = new OleDbConnection(strConnectionString);
    SQLConn.Open();
    OleDbDataAdapter SQLAdapter = new OleDbDataAdapter();
    string sql = "SELECT * FROM [" + sheetName + "$]";
    OleDbCommand selectCMD = new OleDbCommand(sql, SQLConn);
    SQLAdapter.SelectCommand = selectCMD;
    SQLAdapter.Fill(dtXLS);
    SQLConn.Close();
