      class Program
     {
        const string ServiceBusConnectionString = "";
        const string QueueName = "";
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {
            var queueClient = QueueClient.CreateFromConnectionString(ServiceBusConnectionString, QueueName);
            string Message = "I'm in Azure Service Bus Queue";
            BrokeredMessage message = new BrokeredMessage(Message);
            await queueClient.SendAsync(message);
        }
}
}`
