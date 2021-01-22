	string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dataSource;
	OleDbConnection connection = new OleDbConnection(connectionString);
	DataTable schemaTable = null;
	string tblName = "xxx";
	try
	{
		connection.Open();
		//obtain column information in table "xxx"
		schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tblName, null });
	}
	catch (Exception ex)
	{
		String str = ex.Message;
	}
	finally
	{
		connection.Close();
	}
	foreach (DataRow row in schemaTable.Rows)
	{
		columnNames.Add(row["COLUMN_NAME"].ToString());
		DataColumn colnum_type = row.Table.Columns["DATA_TYPE"] as DataColumn;	//note this line
		ColumnDataTypes.Add(colnum_type.DataType);
	}
