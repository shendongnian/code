    public static IDBHelper Helper = new DBUPHelper();
    private static ILogger logObj;
    [FunctionName("HttpStart")]
    public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, methods: "post", Route = "orchestrators/{functionName}")] HttpRequestMessage req,
        [OrchestrationClient] DurableOrchestrationClientBase starter,
        string functionName,
        ILogger log, ExecutionContext context)
    {
       HttpResponseMessage response = null;      
       if (helper.UpgradeDB()) {
           log.LogInformation("DB Upgraded Successfully");
           logObj = log;
           try
           {
               var provider = new MultipartMemoryStreamProvider();
               await req.Content.ReadAsMultipartAsync(provider);
               Application policy = await GeneratePolicyObject(provider);
               string instanceId = await starter.StartNewAsync(functionName, policy);
               log.LogInformation($"Started orchestration with ID = '{instanceId}'.");
               response = starter.CreateCheckStatusResponse(req, instanceId);
               response.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromSeconds(10));
           }
           catch (Exception ex)
           {
               response = new HttpResponseMessage();
               log.LogCritical(ex.ToString());
               log.LogCritical(ex.InnerException.ToString());
               log.LogCritical(ex.StackTrace);
               response.Content = new StringContent(ex.ToString());
               response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
           }
       }
       else log.LogCritical("DB Upgrade Failed. Check logs for exception");
       return response;
    }
