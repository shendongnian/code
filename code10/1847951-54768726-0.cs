    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;
    
    namespace KeyVault
    {
        public static class MyFunctionClass
        {
            private static string superSecret = System.Environment.GetEnvironmentVariable("SuperSecret");
            
            [FunctionName("MyFunction")]
            public static void Run([EventHubTrigger("eventhub", Connection = "EventHubConnectionString")]string myEventHubMessage, ILogger log)
            {
                // DISCLAIMER: Never log secrets. Just a demo :)
                log.LogInformation($"Shhhhh.. it's a secret: {superSecret}");
            }
        }
    }
