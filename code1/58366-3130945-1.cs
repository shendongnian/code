    static DataTable CsvToDataTable(string strFileName)
    {
    	DataTable dataTable = new DataTable("DataTable Name");
    
    	using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + Directory.GetCurrentDirectory() + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\""))
    	{
    	    conn.Open();
    	    string strQuery = "SELECT * FROM [" + strFileName + "]";
    	    OleDbDataAdapter adapter = 
                new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
    	    adapter.Fill(dataTable);
    	}
    	return dataTable;
    }
