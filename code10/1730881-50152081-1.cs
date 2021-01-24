    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("%queuename1%")] string message, TextWriter log)
        {
            log.WriteLine(message);
            Console.WriteLine("success");
        }
        public static void ProcessQueueMessage1([QueueTrigger("%queuename2%")] string message, TextWriter log)
        {
            log.WriteLine(message);
            Console.WriteLine("success2");
        }
    }
