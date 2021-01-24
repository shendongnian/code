      public static partial class EnumerableExtensions {
        internal sealed class MyGrouping<TKey, TElement> : IGrouping<TKey, TElement> {
          private readonly IEnumerable<TElement> m_Values;
    
          public MyGrouping(TKey key, IEnumerable<TElement> values) {
            if (values == null)
              throw new ArgumentNullException("values");
    
            Key = key;
            m_Values = values;
          }
    
          public TKey Key {
            get;
          }
    
          public IEnumerator<TElement> GetEnumerator() {
            return m_Values.GetEnumerator();
          }
    
          System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
          }
        }
    
        public static IEnumerable<IGrouping<TKey, TSource>> GroupByRestricted<TSource, TKey>(
          this IEnumerable<TSource> source,
               Func<TSource, TKey> keySelector,
               int size = int.MaxValue) {
    
          if (null == source)
            throw new ArgumentNullException("source");
          else if (null == keySelector)
            throw new ArgumentNullException("keySelector");
          else if (size <= 0)
            throw new ArgumentOutOfRangeException("size", "size must be positive");
    
          Dictionary<TKey, List<TSource>> dict = new Dictionary<TKey, List<TSource>>();
    
          foreach (var item in source) {
            var key = keySelector(item);
    
            List<TSource> list = null;
    
            if (!dict.TryGetValue(key, out list)) {
              list = new List<TSource>();
    
              dict.Add(key, list);
            }
    
            list.Add(item);
    
            if (list.Count >= size) {
              yield return new MyGrouping<TKey, TSource>(key, list.ToArray());
    
              list.Clear();
            }
          }
    
          foreach (var item in dict.Where(pair => pair.Value.Any()))
            yield return new MyGrouping<TKey, TSource>(item.Key, item.Value.ToArray());
        }
      }
