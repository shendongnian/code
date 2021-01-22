    public class GenericEventArgs<T> : EventArgs
    {
        public T EventData { get; private set; }
        public GenericEventArgs(T EventData)
        {
            this.EventData = EventData;
        }
    }
