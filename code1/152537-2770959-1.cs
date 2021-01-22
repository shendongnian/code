    public interface IOrderable
    {
        int SortOrder { get; }
    }
    public virtual IEnumerable<T> GetAll<T>() where T : class, IOrderable
    {
        ...
    }
