    public interface IMetadata
    {
        Type DataType { get; }
        object Data { get; }
    }
    public interface IMetadata<TData> : IMetadata
    {
        new TData Data { get; }
    }
