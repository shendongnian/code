	private static List<Stream> GetDatabaseAsBinary(string[] tablesToBackup, string connectionString)
	{
		var connection = new OleDbConnection("Provider=SQLOLEDB; " + connectionString);
		connection.Open();
		var streams = new List<Stream>();
		foreach (var tableName in tablesToBackup) {
			streams.Add(GetTableAsBinary(tableName, connection));
		}
		return streams;
	}
	private static Stream GetTableAsBinary(string table, OleDbConnection oleDbConnection)
	{
		var oleDbDataAdapter = new OleDbDataAdapter(string.Format("select * from {0}", table), oleDbConnection);
		var dataSet = new DataSet();
		oleDbDataAdapter.Fill(dataSet, table);
		dataSet.RemotingFormat = SerializationFormat.Binary;
		var format = new BinaryFormatter();
		var memStream = new MemoryStream();
		format.Serialize(memStream, dataSet);
		return memStream;          
	}
