        public static DynamoDBOperationConfig GetDynamoDbOperationConfig(string dynamoDbTable)
        {
            DynamoDBOperationConfig config = new DynamoDBOperationConfig() { OverrideTableName = dynamoDbTable };
            return config;
        } 
