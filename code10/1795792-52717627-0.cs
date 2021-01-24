    public static class Function1
    {
        private static TelemetryClient telemetryClient = new TelemetryClient() { InstrumentationKey = "your_key" };
        [FunctionName("Function2")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequestMessage req)
        {
            RequestTelemetry requestTelemetry = new RequestTelemetry { Name = "Function211" };
            var operation = telemetryClient.StartOperation(requestTelemetry);
            telemetryClient.TrackTrace("trace message 111", SeverityLevel.Error);
            telemetryClient.TrackException(new System.Exception("My custom exception 111"));
            operation.Telemetry.Success = true;
            telemetryClient.StopOperation(operation);
            return req.CreateResponse(HttpStatusCode.OK, "Hello ");
        }
    }
