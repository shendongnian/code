    public abstract class QueueMessage<T>
    {
        // prevents unwanted subclassing
        private QueueMessage() { }
        public abstract TReturn Match<TReturn>(Func<TReturn> clearCase, Func<TReturn> tryDequeueCase, Func<T, TReturn> enqueueCase);
        public static QueueMessage<T> MakeClearMessage() { return new ClearMessage(); }
        public static QueueMessage<T> MakeTryDequeueMessage() { return new TryDequeueMessage(); }
        public static QueueMessage<T> MakeEnqueueMessage(T item) { return new EnqueueMessage(item); }
        
        private sealed class ClearMessage : QueueMessage<T>
        {
            public ClearMessage() { }
            public override TReturn Match<TReturn>(Func<TReturn> clearCase, Func<TReturn> tryDequeueCase, Func<T, TReturn> enqueueCase)
            {
                return clearCase();
            }
        }
        private sealed class TryDequeueMessage : QueueMessage<T>
        {
            public TryDequeueMessage() { }
            public override TReturn Match<TReturn>(Func<TReturn> clearCase, Func<TReturn> tryDequeueCase, Func<T, TReturn> enqueueCase)
            {
                return tryDequeueCase();
            }
        }
        private sealed class EnqueueMessage : QueueMessage<T>
        {
            private T item;
            public EnqueueMessage(T item) { this.item = item; }
            
            public override TReturn Match<TReturn>(Func<TReturn> clearCase, Func<TReturn> tryDequeueCase, Func<T, TReturn> enqueueCase)
            {
                return enqueueCase(item);
            }
        }
    }
