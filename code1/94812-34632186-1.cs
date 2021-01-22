    public static class IEnumerableExtensions {
      /// <summary>
      /// Instantiates and returns a <see cref="CachedEnumerable{T}"/> for a given <paramref name="enumerable"/>.
      /// Notice: The first item is always iterated through.
      /// </summary>
      public static CachedEnumerable<T> ToCachedEnumerable<T>(this IEnumerable<T> enumerable) {
        return CachedEnumerable<T>.Create(enumerable);
      }
    }
