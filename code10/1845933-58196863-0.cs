    public static async Task<object> RunOrchestrator(
        [OrchestrationTrigger] DurableOrchestrationContext context,
        ILogger log)
    {
        // orchestration logic here
    }
    
    [FunctionName("Info_HttpStart1")]
    public static async Task<HttpResponseMessage> HttpStart(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "starter1")]HttpRequestMessage req,
        [OrchestrationClient]DurableOrchestrationClient starter,
        ILogger log)
    {
        // Function input comes from the request content.
        string instanceId = await starter.StartNewAsync("Info", null);
    
        log.LogInformation($"Started orchestration with ID = '{instanceId}'.");
    
        return starter.CreateCheckStatusResponse(req, instanceId);
    }
    [FunctionName("Info_HttpStart2")]
    public static async Task<HttpResponseMessage> HttpStart(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "starter2")]HttpRequestMessage req,
        [OrchestrationClient]DurableOrchestrationClient starter,
        ILogger log)
    {
        // Function input comes from the request content.
        string instanceId = await starter.StartNewAsync("Info", null);
    
        log.LogInformation($"Started orchestration with ID = '{instanceId}'.");
    
        return starter.CreateCheckStatusResponse(req, instanceId);
    }
