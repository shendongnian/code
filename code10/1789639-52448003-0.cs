    private static Lazy<DocumentClient> lazyClient = new Lazy<DocumentClient>(InitializeDocumentClient);
    private static DocumentClient client => lazyClient.Value;
    private static DocumentCollection graph;
    private static DocumentClient InitializeDocumentClient()
    {
        // Perform any initialization here
        var uri = new Uri("example");
        var authKey = "authKey";
        
        var client = new DocumentClient(uri, authKey, new ConnectionPolicy
                {
                    ConnectionMode = ConnectionMode.Direct,
                    ConnectionProtocol = Protocol.Tcp
                });
                
        // get a reference to the database the console app created
        Database database = client.CreateDatabaseIfNotExistsAsync(
        new Database
        {
            Id = "cloudcasegraph"
        }).Result;
        graph = client.CreateDocumentCollectionIfNotExistsAsync(
            UriFactory.CreateDatabaseUri("cloudcasegraph"),
            new DocumentCollection { Id = "poc-graph1" },
            new RequestOptions { OfferThroughput = 400 }
            ).Result;
                
        return client;
    }
    [FunctionName("Search")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            // the person objects will be free-form in structure
            List<dynamic> results = new List<dynamic>();
           
            // Get the gremlinquery from the headers
            IEnumerable<string> headerValues = req.Headers.GetValues("gremlinquery");
            var gremlinquery = headerValues.FirstOrDefault();
            //Make the query against the graph
            IDocumentQuery<dynamic> query = client.CreateGremlinQuery<dynamic>(graph, string.Format("{0}", gremlinquery));
            // iterate over all the results and add them to the list
            while (query.HasMoreResults)
                foreach (dynamic result in await query.ExecuteNextAsync())
                    results.Add(result);
        
            // return the list with an OK response
            return req.CreateResponse<List<dynamic>>(HttpStatusCode.OK, results);
        }
    
