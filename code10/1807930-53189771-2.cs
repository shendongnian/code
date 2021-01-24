	public static void InsertMySql(string connectionString, string command, DataTable data)
	{
	    using (var connection = new MySqlConnection(connectionString))
	    {
	        connection.Open();
			var bulk = new BulkOperation(connection);
			bulk.BulkInsert(data); //assumes your data table's table name, column names/definitions match your table's; I think.  See https://bulk-operations.net/bulk-insert for what documentation's available
		}
	}
