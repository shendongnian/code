    public interface IContainer
    {
        IEnumerable<IContent> Contents { get; }
    }
    public interface IContainer<T> : IContainer { ... }
