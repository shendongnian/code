    public interface Thing<T>
    {
        String Name { get; }
        IList<IItem<ThingParameterBase>> thingItems { get; }
    }
