    [FunctionName("MyPOSTFunction")]
    public static async Task Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/resource/" )]
        SomeEntityModel entityModel, 
        ILogger logger) {
        // ...
    }
