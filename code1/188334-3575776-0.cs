      public class InfiniteEnumerator<T> : IEnumerator<T>
        {
            private IList<T> _items;
            private int _index = -1;
    
            public InfiniteEnumerator(IList<T> items)
            {
                if (items == null)
                {
                    throw new ArgumentNullException("items");
                }
                _items = items;
            }
    
            public T Current
            {
                get { return _items[_index]; }
            }
    
            public void Dispose()
            {
                
            }
    
            object System.Collections.IEnumerator.Current
            {
                get { return _items[_index]; }
            }
    
            public bool MoveNext()
            {
                if (_items.Count == 0)
                {
                    return false;
                }
    
                _index = (_index + 1) % _items.Count;
                return true;
            }
    
            public void Reset()
            {
                _index = -1;
            }
        }
