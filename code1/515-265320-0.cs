String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\InputDirectory\\;Extended Properties='text;HDR=Yes;FMT=Delimited'";
OleDbConnection objConn = new OleDbConnection(sConnectionString);
objConn.Open();
DataTable dt = new DataTable();
OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM file.csv", objConn);
OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
objAdapter1.SelectCommand = objCmdSelect;
objAdapter1.Fill(dt);
objConn.Close();
