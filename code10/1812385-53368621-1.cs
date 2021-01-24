    private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
         string excelConnStr = string.Empty;
         OleDbCommand excelCommand = new OleDbCommand();
         if (FilePath.EndsWith(".xlsx"))
         {
             excelConnStr =string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};Extended Properties='Excel 8.0;HDR=No'", FilePath);
         }
         else
         {
             excelConnStr= string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Extended Properties='Excel 8.0;HDR=No'", FilePath);
         }
         string selectedSheet= (sender as ComboBox).SelectedItem as string;
         OleDbConnection excelConn = new OleDbConnection(excelConnStr);
         OleDbCommand cmdExcel = new OleDbCommand();
         OleDbDataAdapter oda = new OleDbDataAdapter();
         cmdExcel.Connection = excelConn;
         excelConn.Open();
         DataTable dtsheet = new DataTable();
         dtsheet = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);                
         OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + selectedSheet + "$]", excelConnStr);
         DataTable dt = new DataTable();
         da.Fill(dt);
         dataGridView1.DataSource = dt;
    }
