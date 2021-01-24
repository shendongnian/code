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
            //you can directly use this line of code.
            //logger.LogError(new Exception(),"it is a test error...");
            //or use the following code
            try
            {
                int i = int.Parse("123er");
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"it's a exception here 0927..........");
            }
            }
        }
    }
