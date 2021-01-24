    public static HttpResponseMessage Run(HttpRequestMessage req, ExecutionContext context)
    {
        var path = System.IO.Path.Combine(context.FunctionDirectory, "twinkle.txt");
        // ...
    }
