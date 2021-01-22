    public interface IInterfaceB<T>
        where T : new()
    {
        List<T> Whatever { get; }
    }
