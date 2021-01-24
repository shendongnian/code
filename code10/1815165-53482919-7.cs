	using (SqlConnection sourceConnection = new SqlConnection(constr))
	{
		sourceConnection.Open();
		SqlCommand commandSourceData = new SqlCommand("select * from XXXX ", sourceConnection);
		using (reader = commandSourceData.ExecuteReader() { //add a using statement for your reader so you don't need to worry about close/dispose
			//keep the connection open or we'll be trying to read from a closed connection
			
			using (SqlBulkCopy bulkCopy = new SqlBulkCopy(constr2))
			{
				bulkCopy.BatchSize = 1000; //Write a few pages at a time rather than all at once; thus lowering memory impact.  See https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlbulkcopy.batchsize?view=netframework-4.7.2
				bulkCopy.DestinationTableName = "destinationTable";
				try
				{
					// Write from the source to the destination.
					bulkCopy.WriteToServer(reader);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					throw; //we've caught the top level Exception rather than somethign specific; so once we've logged it, rethrow it for a proper handler to deal with up the call stack
				}
			}
		}
		
	}
