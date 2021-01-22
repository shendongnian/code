    public class Pool<T> : IDisposable
    {
        // Other code - we'll come back to this
        interface IItemStore
        {
            T Fetch();
            void Store(T item);
            int Count { get; }
        }
    }
