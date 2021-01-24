    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
     public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("myqueue", Connection = "AzureWebJobsStorage")]string myQueueItem, TraceWriter log)
        {
    
            log.Info($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
