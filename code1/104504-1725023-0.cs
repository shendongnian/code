    static class TreeExtensions
    {
      public static IEnumerable<R>TraverseDepthFirst<T, R>(
          this T t,
          Func<T, R> valueselect,
          Func<T, IEnumerable<T>> childselect)
      {
        yield return valueselect(t);
    
        foreach (var i in childselect(t))
        {
          foreach (var item in i.TraverseDepthFirst(valueselect, childselect))
          {
            yield return item;
          }
        }
      }
    }
