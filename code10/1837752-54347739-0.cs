    public IEnumerable<List<T>> QueryRecords<T>() where T : class, ITableEntity, new()
    {
        TableContinuationToken token = null;
        do
        {
            var queryResult = tableClient.ExecuteQuerySegmented(new TableQuery<T>(), token);
            token = queryResult.ContinuationToken;
            yield return queryResult.Results;
        } while (token != null);
    }
