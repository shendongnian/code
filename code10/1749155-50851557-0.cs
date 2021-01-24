    public static HttpResponseMessage Run(HttpRequestMessage req, ExecutionContext context)
    {
        var message = $"You are in {context.FunctionDirectory}";
        return req.CreateResponse(System.Net.HttpStatusCode.OK, message );
    }
