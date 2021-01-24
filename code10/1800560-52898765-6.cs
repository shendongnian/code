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
    
            public Task<List<T>> GetAsync(IEnumerable<ScanCondition> conditions)
            {
                return ScanAsync<T>(conditions, _config).GetRemainingAsync();
            }
    
            public Task SaveAsync(T item)
            {
                return base.SaveAsync(item, _config);
            }
        }
