    public static class ChildOrderHelper
    {
      public static IEnumerable<T> OrderChildren<T>(IEnumerable<T> children) where T : IHasChildID
      {
        var childrenList = children.ToList();
        //just a simple example of what I'm guessing the method could do...
        return childrenList.OrderBy(c => c.GetChildID()).ToList();
      }
    }
