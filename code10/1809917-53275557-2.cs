        public class Functions
        {
            // This function will get triggered/executed when a new message is written 
            // on an Azure Queue called queue.
            public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TraceWriter log)
            {
                log.Info("1113 this is a queue message: "+message);
                log.Info("1113 it is a test from azure web jobs!!!");
            }
        }
