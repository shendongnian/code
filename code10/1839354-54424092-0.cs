    [FunctionName("WebrootConnector")]
    public static void Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        [CosmosDB(
            databaseName: "customersDB",
            collectionName: "customers",
            ConnectionStringSetting = "CosmosDBConnection", 
            CreateIfNotExists = true,
            Id = "999",
            PartitionKey = "/id")] 
            Customers customersObject, // in binding
         [CosmosDB(
            databaseName: "customersDB",
            collectionName: "customers",
            ConnectionStringSetting = "CosmosDBConnection"] 
            out dynamic customersDocumentToDB, // out binding
            ILogger log)
