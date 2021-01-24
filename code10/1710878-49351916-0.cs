    public class MessageService<TConfig> : IMessageService<TConfig> where TConfig : IConfig
    {
        public MessageService(IMessageQueue<TConfig> messageQueue)
        {
        }
    }
    public class MessageQueue<TConfig> : IMessageQueue<TConfig> where TConfig : IConfig
    {
        public MessageQueue(TConfig config)
        {
        }
    }
    public class TopLevelMessageDispatcher
    {
        public TopLevelMessageDispatcher(IMessageService<DispatcherConfig> messageService)
        {
        }
    }
    public class TopLevelMessageConsumer
    {
        public TopLevelMessageConsumer(IMessageService<ConsumerConfig> messageService)
        {
        }
    }
