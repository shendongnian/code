    public class Foo
    {
      public static List<Bar> EmptyBarList = new List<Bar>().AsReadOnly();
    
      public List<Bar> GetBars()
      {
        return InnerGetBars() ?? EmptyBarList;
      }
    }
