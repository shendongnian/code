    static class Helper
    {
      public static List<T> SaveRest<T>(this IEnumerator<T> enumerator)
      {
        var list = new List<T>();
        while (enumerator.MoveNext())
        {
          list.Add(enumerator.Current);
        }
        return list;
      }
      public static ArrayList SaveRest(this IEnumerator enumerator)
      {
        var list = new ArrayList();
        while (enumerator.MoveNext())
        {
          list.Add(enumerator.Current);
        }
        return list;
      }
    }
