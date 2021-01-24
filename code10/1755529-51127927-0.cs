    DataTable csvTableSchema = new DataTable();
    
    //Open the CSV
    string csvFilePath = "C:\\temp\\A.csv";
    var connString = string.Format(
        @"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""",
        Path.GetDirectoryName(csvFilePath)
    );
    
    //To read the csv with DataTypes we specify the columns and their datatypes in the Schema.ini
    //REF https://docs.microsoft.com/en-us/sql/odbc/microsoft/schema-ini-file-text-file-driver
    
    using (var conn = new OleDbConnection(connString))
    {
        conn.Open();
        var query = "SELECT * FROM [" + Path.GetFileName(csvFilePath) + "]";
        using (var adapter = new OleDbDataAdapter(query, conn))
        {
            var ds = new DataSet("CSV File");
            adapter.Fill(ds);
            csvTableSchema = ds.Tables[0];
        }
    }
