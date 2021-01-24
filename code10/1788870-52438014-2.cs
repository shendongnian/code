    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    
    namespace WebJob7
    {
        public class Functions
        {
            // This function will get triggered/executed when a new message is written 
            // on an Azure Queue called queue.
            public static void ProcessQueueMessage([QueueTrigger("queue")] string message, ILogger logger)
            {
                logger.LogInformation("hello: "+message);
                logger.LogError("it is a test error...");
            }
        }
    }
