    public interface IContainer
    {
        IEnumerable SaveToCache(IEnumerable models);
    }
    public interface IContainer<T> : IContainer
    {
        IEnumerable<T> SaveToCache(IEnumerable<T> models);
    }
