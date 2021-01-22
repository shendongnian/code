    public class Synchronized<T>
    {
        private readonly object sync = new Object();
        private T item;
        public Synchronized(T item)
        {
            this.item = item;
        }
        public void Execute(Action<T> action)
        {
            lock (sync)
                action(item);
        }
        public TResult Evaluate<TResult>(Func<T, TResult> selector)
        {
            lock (sync)
                return selector(item);
        }
    }
