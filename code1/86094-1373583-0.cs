    public string BuildExcelConnectionString(string Filename, bool FirstRowContainsHeaders){
          return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;
          Data Source='{0}';Extended Properties=\"Excel 8.0;HDR={1};\"",
           Filename.Replace("'", "''"),FirstRowContainsHeaders ? "Yes" : "No");
    }
    
    public string BuildExcel2007ConnectionString(string Filename, bool FirstRowContainsHeaders){
          return string.Format("Provider=Microsoft.ACE.OLEDB.12.0;
           Data Source={0};Extended Properties=\"Excel 12.0;HDR={1}\";",
             Filename.Replace("'", "''"),FirstRowContainsHeaders ? "Yes" : "No");
    
    }
    
    private void ReadExcelFile(){
      string connStr = BuildExcel2007ConnectionString(@"C:\Data\Spreadsheet.xlsx", true);
      string query = @"Select * From [Sheet1$] Where Row = 2";
      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connStr);
      
      conn.Open();
      System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, conn);
      System.Data.OleDb.OleDbDataReader dr = cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      dr.Close();
      conn.Close(); 
    }
