    public interface ISomeCollection
    {
        int Count { get; }
        void Clear();
    }
    public interface ISomeCollection<T> : ISomeCollection
    {
        void Add(T item);
    }
