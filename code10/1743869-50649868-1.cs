    using System;
    using System.Threading.Tasks;
    using Microsoft.ServiceBus.Messaging;
    
    namespace ServiceBusSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string ConnectionString = "your service bus connection string";
                const string QueueName = "your service bus queue name";
                string message = "Hello World!";
                string sessionId = Guid.NewGuid().ToString();
    
                SendMessage(ConnectionString, QueueName, sessionId, message).Wait();
    
                Console.WriteLine("Press <ENTER> to exit...");
                Console.ReadLine();
            }
    
            private static async Task SendMessage(string connectionString, string queueName, string sessionId, string message, string correlationId = null)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(connectionString))
                    {
                        throw new ArgumentException("Service bus connection string cannot be null, empty or whitespace.");
                    }
    
                    if (string.IsNullOrWhiteSpace(queueName))
                    {
                        throw new ArgumentException("Service bus queue name cannot be null, empty or whitespace.");
                    }
    
                    if (string.IsNullOrWhiteSpace(sessionId))
                    {
                        throw new ArgumentException("Session id cannot be null, empty or whitespace.");
                    }
    
                    QueueClient queueClient = QueueClient.CreateFromConnectionString(connectionString, queueName);
    
                    BrokeredMessage brokeredMessage = new BrokeredMessage(message);
                    brokeredMessage.SessionId = sessionId;
    
                    await queueClient.SendAsync(brokeredMessage);
                }
                catch
                {
                    // TODO: Handle exception appropriately (including logging)
                    throw;
                }
            }
        }
    }
