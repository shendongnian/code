    [FunctionName("HttpTriggerWithSingleDocument")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req,
            [DocumentDB(databaseName: "your-db",
                collectionName: "your-collection",
                ConnectionStringSetting = "CosmosDBConnectionString")] out dynamic documentToSave)
        {
            dynamic data = await req.Content.ReadAsAsync<object>();
        
            if (data == null)
            {
                documentToSave = null;
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }
            documentToSave = data;
            return req.CreateResponse(HttpStatusCode.Created);
    }
