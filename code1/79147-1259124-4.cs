    public interface IReadableList<out T> : IEnumerable<T>
    {
        T Get(int index);
    }
    public interface IWritableList<in T>
    {
        void Add(T item);
        void Set(int index, T item);
    }
     public interface IMyList<T> : IReadableList<T>, IWritableList<T> {}
