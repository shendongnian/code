        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("QUEUENAME")] string message, TextWriter log)
        {
           // your code
        }
