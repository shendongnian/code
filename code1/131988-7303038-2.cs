    private class ClearMessage
    {
        public static readonly ClearMessage Instance = new ClearMessage();    
        private ClearMessage() { }
    }
    
    private class TryDequeueMessage 
    {
        public static readonly TryDequeueMessage Instance = new TryDequeueMessage();    
        private TryDequeueMessage() { }
    }
    
    private class EnqueueMessage
    {
        public TValue Item { get; private set; }    
        private EnqueueMessage(TValue item) { Item = item; }
    }
