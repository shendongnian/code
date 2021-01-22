            OleDbConnection MyConnection;
            DataSet DtSet;
            OleDbDataAdapter MyCommand;
            
            MyConnection = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\Book.xlsx;Extended Properties=Excel 12.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            DtSet = new System.Data.DataSet();
            
            MyCommand.Fill(DtSet);
            dataGridView1.DataSource = DtSet.Tables[0];
            MyConnection.Close();
