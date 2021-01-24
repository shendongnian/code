            var request = new UpdateItemRequest
            {
                Key = new Dictionary<string, AttributeValue>() { { "ViewUid", new AttributeValue { S = "replaceVideoIdhere" } } },
                ExpressionAttributeNames = new Dictionary<string, string>()
                {
                    {"#Q", "ViewCount"}
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
                {
                    {":incr", new AttributeValue {N = "1"}}
                },
                UpdateExpression = "SET #Q = #Q + :incr",
                TableName = tableName
            };
            
            var response = await _dynamoDbClient.UpdateItemAsync(request);
            
