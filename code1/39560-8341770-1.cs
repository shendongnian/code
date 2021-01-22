    public class GenericEvent<T> where T:EventArgs
    {
        public event EventHandler<T> Source = delegate { };
        public void Raise(object sender, T arg = default(T))
        {
            Source(sender, arg);
        }
        public void Raise(T arg = default(T))
        {
            Source(this, arg);
        }
        public void AddHandler(EventHandler<T> handler)
        {
            Source += handler;
        }
        public void RemoveHandler(EventHandler<T> handler)
        {
            Source -= handler;
        }
        public static GenericEvent<T> operator +(GenericEvent<T> genericEvent, EventHandler<T> handler)
        {
            genericEvent.AddHandler(handler);
            return genericEvent;
        }
    }
