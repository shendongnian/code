    String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filename + ";" + "Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1ReadOnly=False\"";
    OleDbConnection objConn = new OleDbConnection(sConnectionString);
    objConn.Open();
    OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [" + sheetname + "$]", objConn);
    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
    objAdapter1.SelectCommand = objCmdSelect;
    DataSet dsExcelContent = new DataSet();
    objAdapter1.Fill(dsExcelContent);
    objConn.Close();
