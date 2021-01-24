    [FunctionName("Function1")]
    public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "HttpTriggerCSharp/name/{fbAppID}/{fbCode}/{fbAppSecret}")]HttpRequestMessage req, string fbAppID, string fbCode, string fbAppSecret, TraceWriter log)
    {
      log.Info("C# HTTP trigger function processed a request.");
      var msg = $"App ID: {fbAppID}, Code: {fbCode}, Secret: {fbAppSecret}";
      // Fetching the name from the path parameter in the request URL
      return req.CreateResponse(HttpStatusCode.OK, msg);
    }
