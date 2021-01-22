    /// <summary>
    /// A <see cref="IEnumerable{T}"/> that caches every item upon first enumeration.
    /// </summary>
    /// <seealso cref="http://blogs.msdn.com/b/matt/archive/2008/03/14/digging-deeper-into-lazy-and-functional-c.aspx"/>
    /// <seealso cref="http://blogs.msdn.com/b/wesdyer/archive/2007/02/13/the-virtues-of-laziness.aspx"/>
    public class CachedEnumerable<T> : IEnumerable<T> {
      private readonly T _item;
      private readonly Lazy<CachedEnumerable<T>> _nextItems;
      /// <summary>
      /// Initialises a new instance of <see cref="CachedEnumerable{T}"/> using <paramref name="item"/> as the current item
      /// and <paramref name="nextItems"/> as a value factory for the <see cref="CachedEnumerable{T}"/> containing the next items.
      /// </summary>
      protected internal CachedEnumerable(T item, Func<CachedEnumerable<T>> nextItems) {
        _item = item;
        _nextItems = new Lazy<CachedEnumerable<T>>(nextItems);
      }
      /// <summary>
      /// Instantiates and returns a <see cref="CachedEnumerable{T}"/> for a given <paramref name="enumerable"/>.
      /// Notice: The first item is always iterated through.
      /// </summary>
      public static CachedEnumerable<T> Create(IEnumerable<T> enumerable) {
        return Create(enumerable.GetEnumerator());
      }
      /// <summary>
      /// Instantiates and returns a <see cref="CachedEnumerable{T}"/> for a given <paramref name="enumerator"/>.
      /// Notice: The first item is always iterated through.
      /// </summary>
      private static CachedEnumerable<T> Create(IEnumerator<T> enumerator) {
        return enumerator.MoveNext() ? new CachedEnumerable<T>(enumerator.Current, () => Create(enumerator)) : null;
      }
      /// <summary>
      /// Returns an enumerator that iterates through the collection.
      /// </summary>
      public IEnumerator<T> GetEnumerator() {
        yield return _item;
        var nextItems = _nextItems.Value;
        if (nextItems != null) {
          foreach (var nextItem in nextItems) {
            yield return nextItem;
          }
        }
      }
      /// <summary>
      /// Returns an enumerator that iterates through a collection.
      /// </summary>
      IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
      }
    }
