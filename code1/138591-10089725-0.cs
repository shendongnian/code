       try
       {        
            DataTable sheetTable = loadSingleSheet(@"C:\excelFile.xls", "Sheet1$");
            dataGridView1.DataSource = sheetTable;
       }
       catch (Exception Ex)
       {
            MessageBox.Show(Ex.Message, "");
       }  
    }        
    private OleDbConnection returnConnection(string fileName)
    {
        return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + "; Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"");
    }
    private DataTable loadSingleSheet(string fileName, string sheetName)
    {           
        DataTable sheetData = new DataTable();
        using (OleDbConnection conn = this.returnConnection(fileName))
        {
           conn.Open();
           // retrieve the data using data adapter
           OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select * from [" + sheetName + "]", conn);
            sheetAdapter.Fill(sheetData);
        }                        
        return sheetData;
   
