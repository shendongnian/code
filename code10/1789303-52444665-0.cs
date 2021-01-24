        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req,
        TraceWriter log)
        {
            dynamic data = await req.Content.ReadAsAsync<object>();
            var connectionString = "DbUri";
            var key = "DbKey";
            using (var client = new DocumentClient(new Uri(connectionString), key))
            {
                var collectionLink = UriFactory.CreateDocumentCollectionUri("DbName", "CollectionName");
                await client.UpsertDocumentAsync(collectionLink, data);
            }
            return req.CreateResponse(HttpStatusCode.OK);
        }
