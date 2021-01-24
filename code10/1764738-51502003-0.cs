    public interface IServiceBus {
        IQueueClient GetQueueClient(string queueName);
    }
    public class ServiceBus : IServiceBus {
        private static readonly string ServiceBusConnectionString =
            ConfigurationManager.AppSettings[ConnectionStringNames.ServiceBus];
        public IQueueClient GetQueueClient(string queueName) {
            return QueueClient.CreateFromConnectionString(ServiceBusConnectionString, queueName);
        }
    }
