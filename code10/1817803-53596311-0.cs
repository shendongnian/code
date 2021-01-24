     [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("%SvcBusTopicName%", "%SvcBusSubscriptionName%", AccessRights.Listen, Connection = "SvcBusConStr")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
