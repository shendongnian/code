    public static class Something {
        public static Func<ISomeDependency> Factory = () => return new SomeDependency();
    
        [FunctionName("Something")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log) { 
            //...
            ISomeDependency tool = Faactory.Invoke();
            var result = await tool.dbCall();
            //...
            return new OkObjectResult(result); 
        }
    }
