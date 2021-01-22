    public class Foo
    {
      public static readonly List<Bar> EmptyBarList = new List<Bar>().AsReadOnly();
    
      public List<Bar> GetBars()
      {
        return InnerGetBars() ?? EmptyBarList;
      }
    }
