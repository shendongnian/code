    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log, ExecutionContext context)
    {
        var data = File.ReadAllText(context.FunctionAppDirectory+"/CanonicalMessage.xml");
        //etc
    }
