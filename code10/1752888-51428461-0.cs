    try {
        OpenFileDialog fBrowse = new OpenFileDialog();
        // With...
        "Excel files(*.xls)|*.xls|All files (*.*)|*.*".FilterIndex = "Import data from Excel file";
        fBrowse.Filter = "Import data from Excel file";
        if ((fBrowse.ShowDialog() == Windows.Forms.DialogResult.OK)) {
            string fname;
            fname = fBrowse.FileName;
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection(("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" 
                            + (fname + (";" + "Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1\""))));
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select Columns names from [sheet$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Ur table name.");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            // If dataset is not empty Then write code here to insert values to DB.
            MyConnection.Close();
        }
        
    }
    catch (Exception ex) {
        MessageBox.Show(ex.ToString);
    }
