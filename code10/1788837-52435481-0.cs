    DynamoDBContextConfig config = new DynamoDBContextConfig()
    {
        TableNamePrefix = "prod-"
    };
    
    _dynamoDBContext = new DynamoDBContext(new AmazonDynamoDBClient(), config);
