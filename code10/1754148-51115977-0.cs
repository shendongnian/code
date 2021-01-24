    var creds = new BasicAWSCredentials(awsId, awsPassword);
    var dynamoClient = new AmazonDynamoDBClient(creds, awsDynamoDbRegion);
    var context = new DynamoDBContext(dynamoClient);
    
    
    var opConfig = new DynamoDBOperationConfig();
    opConfig.QueryFilter = new List<ScanCondition>();
    opConfig.QueryFilter.Add(new ScanCondition("name", ScanOperator.Equal, myName));
    var response = await context.QueryAsync<Data>(myId, opConfig).GetRemainingAsync();
    return response;
