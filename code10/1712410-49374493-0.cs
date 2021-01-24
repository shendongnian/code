    public interface IDataSource
    {
        IEnumerable GetData();
    }
    public interface IDataSource<TData> : IDataSource
    {
        IEnumerable<TData> GetData();
    }
