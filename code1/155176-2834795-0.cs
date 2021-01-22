    public static class Program
    {
      public static void Main()
      {
        IEnumerable<object> lhs = new List<int> { 1, 2, 3, 4, 5 };
        IEnumerable<object> rhs = new List<int> { 3, 4, 5, 6, 7 };
        foreach (object item in IntersectExample.Intersect(lhs, rhs))
        {
          Console.WriteLine(item);
          break;
        }
      }
    }
    public static class IntersectExample
    {
      public static IEnumerable<object> Intersect(IEnumerable<object> lhs, IEnumerable<object> rhs)
      {
        var hashset = new HashSet<object>();
        foreach (object item in lhs)
        {
          if (!hashset.Contains(item))
          {
            hashset.Add(item);
          }
        }
        foreach (object item in rhs)
        {
          if (hashset.Contains(item))
          {
            yield return item;
          }
        }
      }
    }
