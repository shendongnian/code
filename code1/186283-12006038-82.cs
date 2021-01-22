	var connStr="Provider=SQLOLEDB.1;"+this.Connection.ConnectionString; 
	OleDbConnection connection = new OleDbConnection(connStr);
	DataSet myDataSet = new DataSet();
	connection.Open();
	string sql = @"SELECT * from Customers";
	OleDbDataAdapter DBAdapter = new OleDbDataAdapter();
	DBAdapter.SelectCommand = new OleDbCommand(sql, connection); 
	DBAdapter.Fill(myDataSet);
	
	myDataSet.Dump();
