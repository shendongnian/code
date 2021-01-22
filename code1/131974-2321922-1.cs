    public enum MessageType { ClearMessage, TryDequeueMessage, EnqueueMessage }
    public abstract class QueueMessage<T>
    {
        // prevents unwanted subclassing
        private QueueMessage() { }
        public abstract MessageType MessageType { get; }
        /// <summary>
        /// Only applies to EnqueueMessages
        /// </summary>
        public abstract T Item { get; }
        public static QueueMessage<T> MakeClearMessage() { return new ClearMessage(); }
        public static QueueMessage<T> MakeTryDequeueMessage() { return new TryDequeueMessage(); }
        public static QueueMessage<T> MakeEnqueueMessage(T item) { return new EnqueueMessage(item); }
        private sealed class ClearMessage : QueueMessage<T>
        {
            public ClearMessage() { }
            public override MessageType MessageType
            {
                get { return MessageType.ClearMessage; }
            }
            /// <summary>
            /// Not implemented by this subclass
            /// </summary>
            public override T Item
            {
                get { throw new NotImplementedException(); }
            }
        }
        private sealed class TryDequeueMessage : QueueMessage<T>
        {
            public TryDequeueMessage() { }
            public override MessageType MessageType
            {
                get { return MessageType.TryDequeueMessage; }
            }
            /// <summary>
            /// Not implemented by this subclass
            /// </summary>
            public override T Item
            {
                get { throw new NotImplementedException(); }
            }
        }
        private sealed class EnqueueMessage : QueueMessage<T>
        {
            private T item;
            public EnqueueMessage(T item) { this.item = item; }
            public override MessageType MessageType
            {
                get { return MessageType.EnqueueMessage; }
            }
            /// <summary>
            /// Gets the item to be enqueued
            /// </summary>
            public override T Item { get { return item; } }
        }
    }
