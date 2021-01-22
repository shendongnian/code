    public interface Thing<T>
    {
        string Name { get; }
        IList<IItem<T>> thingItems { get; }
    }
