      private class CachedEnumeration<T> : IEnumerable<T>  
      {  
        /// <summary>  
        /// enumerator for the cachedEnumeration class  
        /// </summary>  
        class CachedEnumerator : IEnumerator<T>  
        {  
          private readonly CachedEnumeration<T> m_source;  
          private int m_index;  
          public CachedEnumerator(CachedEnumeration<T> source)  
          {  
            m_source = source;  
            // start at index -1, since an enumerator needs to start with MoveNext before calling current  
            m_index = -1;  
          }  
          public T Current { get { return m_source.m_items[m_index]; } }  
          public void Dispose() { }  
          object System.Collections.IEnumerator.Current { get { return Current; } } 
          public bool MoveNext()  
          {  
            // if we have cached items, just increase our index  
            if (m_source.m_items.Count > m_index + 1)  
            {  
              m_index++;  
              return true;  
            }  
            else 
            {  
              var result = m_source.FetchOne();  
              if (result) m_index++;  
              return result;  
            }  
          }  
          public void Reset()  
          {  
            m_index = -1;  
          }  
        }  
        /// <summary>  
        /// list containing all the items  
        /// </summary>  
        private readonly List<T> m_items;  
        /// <summary>  
        /// callback how to fetch an item  
        /// </summary>  
        private readonly Func<Tuple<bool, T>> m_fetchMethod;  
        private readonly int m_targetSize;  
        public CachedEnumeration(int size, T firstItem, Func<Tuple<bool, T>> fetchMethod)  
        {  
          m_items = new List<T>(size);  
          m_items.Add(firstItem);  
          m_fetchMethod = fetchMethod;  
          m_targetSize = size;  
        }  
        public IEnumerator<T> GetEnumerator()  
        {  
          return new CachedEnumerator(this);  
        }  
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()  
        {  
          return GetEnumerator();  
        }  
        private bool FetchOne()  
        {  
          if (IsFull) return false;  
          var result = m_fetchMethod();  
          if (result.Item1) m_items.Add(result.Item2);  
          return result.Item1;  
        }  
        /// <summary>  
        /// fetches all items to the cached enumerable  
        /// </summary>  
        public void FetchAll()  
        {  
          while (FetchOne()) { }  
        }  
        /// <summary>  
        /// tells weather the enumeration is already full  
        /// </summary>  
        public bool IsFull { get { return m_targetSize == m_items.Count; } }  
      }  
      /// <summary>  
      /// partitions the <paramref name="source"/> to parts of size <paramref name="size"/>  
      /// </summary>  
      public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)  
      {  
        if (source == null) throw new ArgumentNullException("source");  
        if (size < 1) throw new ArgumentException(string.Format("The specified size ({0}) is invalid, it needs to be at least 1.", size), "size");  
        var enumerator = source.GetEnumerator();  
        while (enumerator.MoveNext())  
        {  
          var lastResult = new CachedEnumeration<T>(size, enumerator.Current, () => Tuple.Create(enumerator.MoveNext(), enumerator.Current));  
          yield return lastResult;  
          lastResult.FetchAll();  
        }  
      }  
