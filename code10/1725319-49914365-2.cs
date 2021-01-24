    private static string key = TelemetryConfiguration.Active.InstrumentationKey = "";
    
    private static TelemetryClient telemetryClient =
    	new TelemetryClient() { InstrumentationKey = key };
    
    [FunctionName("Function1")]
    public static async Task<HttpResponseMessage> Run(
    	[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestMessage req,
    	ILogger log,
    	TraceWriter writer)
    {
    	telemetryClient.Context.Cloud.RoleName = "AIFunction";
    	log.LogInformation($"C# ServiceBus queue trigger function processed message: ");
    	log.LogInformation($"C# ServiceBus queue trigger function to test Application Insight Logging");
    	writer.Info("C# ServiceBus queue trigger function processed message: ");
    	writer.Info("C# ServiceBus queue trigger function to test Application Insight Logging");
    	telemetryClient.TrackEvent("AIFunction TrackEvent");
    	telemetryClient.TrackTrace("AIFunction TrackTrace");
    
    	return req.CreateResponse(HttpStatusCode.OK, "Hello!");
    }
