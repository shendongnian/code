    public interface IItem
    {
      string Name { get; set; }
    }
    
    public interface IItem<T>: IItem
    {
      T Value { get; set; }
    }
    
    public interface IThing
    {
        string Name { get; }
        IList<IItem> Items { get; }
    }
    
    public interface IThing<T>: IThing
    {
        string Name { get; }
        IList<IItem<T>> Items { get; }
    }
