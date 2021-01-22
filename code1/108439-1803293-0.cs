    interface IUntypedItem
    {
      object UntypedData {get; }
    }
    
    interface IItem<T> : IUntypedItem
    {
      T Data {get; set;}
    }
    
    class abstract ItemGeneric<T> : IItem<T>
    {
      T Data { get; set; }
      object UntypedData { get { return Data; }}
    }
    class ItemText : ItemGeneric<string>
    {
    }
