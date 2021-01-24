    [FunctionName("UIHandler")]
    public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "{name}")] HttpRequest req,
        string name, 
        TraceWriter log, 
        [Blob("samples-workitems/{name}", FileAccess.Read)] Stream stream)
    {
        log.Info($"C# HTTP trigger function processed a request for {name}.");
        return new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StreamContent(stream)
        };
    }
