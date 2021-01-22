    public interface Thing<T>
    {
        String Name { get; }
        IList<IItem<T>> thingItems { get; }
    }
