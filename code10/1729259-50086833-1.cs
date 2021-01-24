            var request = new CreateTableRequest
            {
                TableName = TABLE_CREATE_ACCOUNT,
                AttributeDefinitions = new List<AttributeDefinition>()
                {
                    new AttributeDefinition
                    {
                        AttributeName = "CommandId",
                        AttributeType = ScalarAttributeType.S
                    }
                },
                KeySchema = new List<KeySchemaElement>()
                {
                    new KeySchemaElement
                    {
                        AttributeName = "CommandId",
                        KeyType = KeyType.HASH
                    }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 1,
                    WriteCapacityUnits = 1
                },
                StreamSpecification = new StreamSpecification
                {
                    StreamEnabled = true,
                    StreamViewType = StreamViewType.NEW_IMAGE
                }
            };
            try
            {
                var response = _db.CreateTableAsync(request);
                var tableDescription = response.Result.TableDescription;
                Console.WriteLine("{1}: {0} ReadCapacityUnits: {2} WriteCapacityUnits: {3}",
                    tableDescription.TableStatus,
                    tableDescription.TableName,
                    tableDescription.ProvisionedThroughput.ReadCapacityUnits,
                    tableDescription.ProvisionedThroughput.WriteCapacityUnits);
                string status = tableDescription.TableStatus;
                Console.WriteLine(TABLE_CREATE_ACCOUNT + " - " + status);
                WaitUntilTableReady(TABLE_CREATE_ACCOUNT);
                // This connects the DynamoDB stream to a lambda function
                Console.WriteLine("Creating event source mapping between table stream '"+ TABLE_CREATE_ACCOUNT + "' and lambda 'ProcessCreateAccount'");
                var req = new CreateEventSourceMappingRequest
                {
                    BatchSize = 100,
                    Enabled = true,
                    EventSourceArn = tableDescription.LatestStreamArn,
                    FunctionName = "ProcessCreateAccount",
                    StartingPosition = EventSourcePosition.LATEST
                };
                var reqResponse =_lambda.CreateEventSourceMappingAsync(req);
                Console.WriteLine("Event source mapping state: " + reqResponse.Result.State);
            }
            catch (AmazonDynamoDBException e)
            {
                Console.WriteLine("Error creating table '" + TABLE_CREATE_ACCOUNT + "'");
                Console.WriteLine("Amazon error code: {0}", string.IsNullOrEmpty(e.ErrorCode) ? "None" : e.ErrorCode);
                Console.WriteLine("Exception message: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating table '" + TABLE_CREATE_ACCOUNT + "'");
                Console.WriteLine("Exception message: {0}", e.Message);
            }
