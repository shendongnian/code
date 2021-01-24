    internal static void BulkInsert(string serverName, string databaseName, string tableName, IDataReader dataReader, Action<SqlBulkCopy> setMappings)
		{
			using (var bulkCopy = new SqlBulkCopy(BuildConnectionString(serverName, databaseName)))
			{
				bulkCopy.DestinationTableName = tableName;
				setMappings(bulkCopy);
				bulkCopy.WriteToServer(dataReader);
			}
		}
