    public interface IFoo
    {
      string Name {get; }
      Type Type { get; }
      object Value {get; set;}
    }
    
    public interface IFoo<T> : IFoo
    {
      T Value {get; set}
    }
