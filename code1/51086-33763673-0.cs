    public interface IIdentifiable<TKey> : IIdentifiable
    {
        TKey Id { get; }
    }
    public interface IIdentifiable
    {
        object Id { get; }
    }
