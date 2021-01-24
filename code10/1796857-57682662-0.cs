    public static partial class SayHelloFunction
    {
        [FunctionName("SayHello")]
        public static async Task<ActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]Person person, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            return person.Name != null ?
                    (ActionResult)new OkObjectResult($"Hello, {person.Name}")
                : new BadRequestObjectResult("Please pass an instance of Person.");
        }
    }
