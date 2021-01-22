    public class AzureQueue<T> where T : IQueueItem
    {
        private IQueueItemFactory<T> _objFactory;
        public AzureQueue(IQueueItemFactory<T> objItemFactory)
        {
            _objFactory = objItemFactory;
        }
        
        public T GetNextItem(TimeSpan tsLease)
        {
            CloudQueueMessage objQueueMessage = _objQueue.GetMessage(tsLease);
            T objItem = _objFactory.FromMessage(objQueueMessage);
            return objItem;
        }
    }
