    OleDbConnection dbConnection = new OleDbConnection (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\BAR.XLS;Extended Properties=""Excel 8.0;HDR=Yes;""");
    dbConnection.Open ();
    try
    {
        // Get the name of the first worksheet:
        DataTable dbSchema = dbConnection.GetOleDbSchemaTable (OleDbSchemaGuid.Tables, null);
        if (dbSchema == null || dbSchema.Rows.Count < 1)
        {
            throw new Exception ("Error: Could not determine the name of the first worksheet.");
        }
        string firstSheetName = dbSchema.Rows [0] ["TABLE_NAME"].ToString ();
    
        // Now we have the table name; proceed as before:
        OleDbCommand dbCommand = new OleDbCommand ("SELECT * FROM [" + firstSheetName + "]", dbConnection);
        OleDbDataReader dbReader = dbCommand.ExecuteReader ();
    
        // And so on...
    }
    finally
    {
        dbConnection.Close ();
    }
