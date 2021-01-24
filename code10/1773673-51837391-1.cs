	var ds = new DataSet();
	var conn = _connNoHeader = new OleDbConnection(string.Format("Provider={0};Extended Properties=\"Excel 8.0;IMEX=1;HDR=No;\";Data Source={1}", provider, filePath));           
	conn.Open();
	DataTable tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, 
                                                 new object[] { null, null, null, "TABLE" });
	Console.WriteLine("The tables are:");
	foreach (DataRow row in tables.Rows)
		Console.Write("  {0}", row[2]);
    // here are all worksheet name
	var allWorksheetNames = tables.Rows.OfType<DataRow>().Select(row => row[2]).ToList();
