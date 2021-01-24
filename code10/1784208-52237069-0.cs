    private SqlConnection CreateTempConnectionIfNeeded()
    {
    	return _sqlConnection == null ? new SqlConnection(_connectionString) : null;
    }
    
    public int BulkInsert<T>(IDataReader dataReader, Dictionary<string, string> columnMappings = null, int timeoutInSeconds = 120)
    {
    	using (var tempConnection = CreateTempConnectionIfNeeded())
    	{
    		return BulkInsert<T>(dataReader, tempConnection ?? _sqlConnection, columnMappings, timeoutInSeconds);
    	}
    }
