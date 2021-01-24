    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.ServiceBus.Messaging;
    
    namespace FunctionApp11
    {
        public static class Function2
        {
            [FunctionName("Function2")]
            public static void Run([ServiceBusTrigger("myqueue", AccessRights.Manage, Connection = "")]string myQueueItem, TraceWriter log)
            {
                log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            }
        }
    }
