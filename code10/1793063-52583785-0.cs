    // Add these...
    using System.Collections;
    using System.Collections.Generic;
    
    //...
    
    public class MyWrapper<T> : IEnumerable<T>
    {
      private IList<T> _internalList;
    
      public MyWrapper(IList<T> list)
      {
        _internalList = list;
      }
    
      public int Count => _internalList.Count;
    
      // the indexer
      public T this[int index]
      {
        get => _internalList[index];
        set => _internalList[index] = value;
      }
    
      public IEnumerator<T> GetEnumerator()
      {
        return _internalList.GetEnumerator();
      }
    
      IEnumerator IEnumerable.GetEnumerator() 
      {
        return this.GetEnumerator();
      }
    }
