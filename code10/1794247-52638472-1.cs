    public class CustomQueueProcessorFactory : IQueueProcessorFactory
    {
        public QueueProcessor Create(QueueProcessorFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Queue.Name == "queuename1")
            {
                context.MaxDequeueCount = 10;
            }
            else if (context.Queue.Name == "queuename2")
            {
                context.MaxDequeueCount = 10;
                context.BatchSize = 1;
            }
            return new QueueProcessor(context);
        }
    }
