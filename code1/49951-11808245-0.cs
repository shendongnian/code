     OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + frmMain.strFilePath + "\\ConfigStructure.mdb");
            myConnection.Open();
            string strTemp = " [KEY] Text, [VALUE] Text ";
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "CREATE TABLE [table1](" + strTemp + ")";
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();
