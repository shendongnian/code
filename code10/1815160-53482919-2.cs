	public Task<SqlDataReader> async ExecuteReaderAsync(string connectionString, string query) 
	{
		SqlConnection connection;
		SqlCommand command; 
		try 
		{
			connection = new SqlConnection(connectionString); //not in a using as we want to keep the connection open until our reader's finished with it.
			connection.Open();
			command = new SqlCommand(query, connection);
			return await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);  //tell our reader to close the connection when done.
		} 
		catch 
		{
		    //if we have an issue before we've returned our reader, dispose of our objects here
			command?.Dispose();
			connection?.Dispose();
			//then rethrow the exception
			throw;
		}
	}
	public async Task CopySqlDataAsync(string sourceConnectionString, string sourceQuery, string destinationConnectionString, string destinationTableName, int batchSize)
	{
		using (var reader = await ExecuteReaderAsync(sourceConnectionString, sourceQuery))
			await CopySqlDataAsync(reader, destinationConnectionString, destinationTableName, batchSize);
	}
	public async Task CopySqlDataAsync(IDataReader sourceReader, string destinationConnectionString, string destinationTableName, int batchSize)
	{
		using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnectionString))
		{
			bulkCopy.BatchSize = batchSize; 
			bulkCopy.DestinationTableName = destinationTableName;
			await bulkCopy.WriteToServerAsync(sourceReader);
		}
	}
	public void CopySqlDataExample()
	{
		try 
		{
			var constr = ""; //todo: define connection string
			var constr2 = ""; //todo: define connection string #2
			var task = CopySqlDataAsync(constr, "select * from XXXX", constr2, "destinationTable", 1000);
			task.Wait(); //waits for the current task to complete / if any exceptions will throw an aggregate exception
		} 
		catch (AggregateException es)
		{
			var e = es.InnerExceptions[0]; //get the wrapped exception 
			Console.WriteLine(e);
			//throw; //to rethrow AggregateException 
			ExceptionDispatchInfo.Capture(e).Throw(); //to rethrow the wrapped exception
		}
	}
	
	
