    var request = new BatchExecutionRequest()
                {
                    Inputs = new Dictionary<string, AzureBlobDataReference>() {
                        {
                            "input1",
                            new AzureBlobDataReference()
                            {
                                ConnectionString = _connectionString,
                                RelativeLocation = $"{_containerName}/{experimentId}/{tenantId}/{trainingDataFileName}.csv"
                            }
                        },
                    },
                    Outputs = new Dictionary<string, AzureBlobDataReference>() {
                        {
                            "output1",
                            new AzureBlobDataReference()
                            {
                                ConnectionString = _connectionString,
                                RelativeLocation = $"{_containerName}/{experimentId}/{tenantId}/{outputFileNameCsv}.csv"
                            }
                        },
                        {
                            "output2",
                            new AzureBlobDataReference()
                            {
                                ConnectionString = _connectionString,
                                RelativeLocation = $"{_containerName}/{experimentId}/{tenantId}/{outputFileNameIlearner}.ilearner"
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
