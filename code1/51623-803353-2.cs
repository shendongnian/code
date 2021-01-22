    public interface Thing<T>
    {
        String Name { get; }
        IList<IItem<IThingParameter>> thingItems { get; }
    }
