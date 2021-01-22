    public interface IDataElement
    {
        int DataElement { get; set; }
    }
    public interface IDataElement<T> : IDataElement
    {
        T Value { get; set; }
    }
