    public class EventArgs<T> : EventArgs
    {
        public T Payload { get; private set }
        public EventArgs(T payload)
        {
            Payload = payload;
        }
    }
