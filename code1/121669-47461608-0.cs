	public static DbDataReader ExecuteReaderClient(DbConnection connection, DbTransaction transaction, String commandText)
	{
		DbCommand command = connection.CreateCommand();
		command.CommandText = commandText;
		if (transaction != null)
			command.Transaction = transaction;
		DbDataAdapter adapter = DbProviderFactories.GetFactory(connection).CreateDataAdapter();
		adapter.SelectCommand = command;
		DataSet dataset = new DataSet();
		try
		{
			adapter.Fill(dataset);
		}
		catch (Exception e)
		{
			throw new Exception(
					  e.Message + "\r\n" +
					  "Command Text" + "\r\n" +
					  commandText, e);
		}
		try
		{
			return dataset.CreateDataReader();
		}
		finally
		{
			dataset.Dispose();
		}
    }
