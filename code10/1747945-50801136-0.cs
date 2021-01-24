    [FunctionName("CategoriesFunction")]
    public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "{website}")] HttpRequestMessage request, 
        string website, 
        TraceWriter log)
