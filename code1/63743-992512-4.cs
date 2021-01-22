    public interface ITag<T> : ITag
    {
        new T InMemValue { get; set; }
        new T OnDiscValue { get; set; }
    }
