class Program
    {
        private static readonly string connectionString = "";
        private static readonly int sleepTime = 100;
       private static readonly int messageCount = 10;
        static void Main(string[] args)
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Https;
            var client = QueueClient.CreateFromConnectionString(connectionString, "testqueue");
            client.PrefetchCount = 1;
            var timeCheck = DateTime.UtcNow;
            client.OnMessage((message) =>
            {
                var timing = (DateTime.UtcNow - message.EnqueuedTimeUtc).TotalMilliseconds;
                Console.WriteLine($"{message.GetBody<string>()}: {timing} milliseconds between between send and receipt.");
            });
            for (int i = 0; i < messageCount; i++)
            {
                client.Send(new BrokeredMessage($"Message {i}"));
                Console.WriteLine($"Message {i} sent");
                Thread.Sleep(sleepTime);
            }
            
            Console.WriteLine("Test Complete");
            
            Console.ReadLine();
        }
    }
  [1]: https://social.msdn.microsoft.com/Forums/en-US/9a3822e7-9af4-4ff4-93c7-ad6ad3234ad4/polling-an-azure-service-bus?forum=azurelogicapps
