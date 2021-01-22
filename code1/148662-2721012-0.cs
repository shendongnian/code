    public interface IRepository<T> : IQueryable<T>
    {
        void Add(T item);
        void Remove(T item);
    }
