    public class Foo
    {
      public static IEnumerable<Bar> EmptyBarEnumerable = new Bar[0];
    
      public IEnumerable<Bar> GetBars()
      {
        return InnerGetBars() ?? EmptyBarEnumerable;
      }
    }
