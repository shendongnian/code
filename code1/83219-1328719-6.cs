       OleDbConnection objConn = new OleDbConnection(sConnectionString);
    
            objConn.Open();
            OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [sheet1$]", objConn);
    
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
            objAdapter1.SelectCommand = objCmdSelect;
    
            DataSet dsExcelContent = new DataSet();
            DataTable dsExcelContent1 = new DataTable();
            objAdapter1.Fill(dsExcelContent);
    
            dataGridView1.DataSource = dsExcelContent1;
            objConn.Close();
    
            int test = dsExcelContent.Tables[0].Rows.Count;
    
