    public List<T> DownloadAnyEntity<T>(string tableId) where T: ITableEntity, new()
    {
        // Reference the CloudTable object
        var tableRef = tableClient.GetTableReference(tableId);
    
        var query = new TableQuery<T>();
        return tableRef.ExecuteQuery(query).ToList();
    }
