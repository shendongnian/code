    public static class IEnumerableExtensions
    {
      public static IEnumerable<ValueWithPrevious<T>> WithPrevious<T>(this IEnumerable<T> @this)
      {
        using (var e = @this.GetEnumerator())
        {
          e.MoveNext();
          var previous = e.Current;
          
          while (e.MoveNext())
          {
            yield return new ValueWithPrevious<T>(e.Current, previous);
            previous = e.Current;
          }
        }
      }
    }
    
    public struct ValueWithPrevious<T>
    {
      public readonly T Value, Previous;
      
      public ValueWithPrevious(T value, T previous)
      {
        Value = value;
        Previous = previous;
      }
    }
