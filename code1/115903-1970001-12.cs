    public class Foo
    {
      public static readonly IEnumerable<Bar> EmptyBarEnumerable = new Bar[0];
    
      public IEnumerable<Bar> GetBars()
      {
        return InnerGetBars() ?? EmptyBarEnumerable;
      }
    }
