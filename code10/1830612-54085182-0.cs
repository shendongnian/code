       public static async Task Run(
             [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req,
             [Blob("pk-api-test/{headers.name}", FileAccess.Read)]Stream myBlob, 
             IDictionary<string, string> headers,
             TraceWriter log)
       {
           string name = headers["name"];
           //...
       }
