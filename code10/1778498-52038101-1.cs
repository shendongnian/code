    public static class Function1
        {
            private static TelemetryClient GetTelemetryClient()
            {
                var telemetryClient = new TelemetryClient();
                telemetryClient.InstrumentationKey = "<your actual insight instrumentkey>";
                telemetryClient.Context.Session.Id = "124556";
                //update 1-Custom properties- Start
                telemetry.Context.Properties["tags"] = "PROD";
                telemetry.Context.Properties["userCorelateId"]="1234"; 
                //update 1-Custom properties- Ends                
                return telemetryClient;
                }       
    
            [FunctionName("Function1")]
            public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
            {
                var appInsights = GetTelemetryClient();           
                appInsights.TrackRequest(req.RequestUri.ToString(), DateTime.Now, Stopwatch.StartNew().Elapsed, "200", true);
                return req.CreateResponse(HttpStatusCode.OK, "message");
    
            }
        
    
        }
