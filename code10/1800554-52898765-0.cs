    public class DynamoDbManager<T> : DynamoDBContext, IDynamoDbManager<T> where T : class
        {
            private DynamoDBOperationConfig _config;
    
            public DynamoDbManager(IAmazonDynamoDB client, string tableName): base(client)
            {
                _config = new DynamoDBOperationConfig()
                {
                    OverrideTableName = tableName
                };
            }
    
            public async Task<List<T>> Get(IEnumerable<ScanCondition> conditions)
            {
                return await ScanAsync<T>(conditions, _config).GetRemainingAsync();
            }
    
            public async Task SaveAsync(T item)
            {
                await base.SaveAsync(item, _config);
            }
        }
