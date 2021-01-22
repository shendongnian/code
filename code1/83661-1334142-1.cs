    public interface ISortable
    {
      Guid SortId { get; }
    }
    
    class Foo : ISortable
    {
      Foo()
      {
        SortId = Guid.NewGuid();
      }
      Guid SortId { get; private set; }
    }
