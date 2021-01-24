    public class Chunk<TKey, TSource> : IGrouping<TKey, TSource>
    {
    
       private readonly ChunkItem _head;    
       private readonly object _mLock = new object(); 
       private IEnumerator<TSource> _enumerator;    
       private bool _isLastSourceElement;    
       private Func<TSource, bool> _predicate;    
       private ChunkItem _tail;
    
       public Chunk(TKey key, IEnumerator<TSource> enumerator, Func<TSource, bool> predicate)
       {
          Key = key;
          _enumerator = enumerator;
          _predicate = predicate;
          _head = new ChunkItem(enumerator.Current);
          _tail = _head;
       }
    
       private bool DoneCopyingChunk => _tail == null;
    
       public TKey Key { get; }
    
       public IEnumerator<TSource> GetEnumerator()
       {  
          var current = _head;
    
          while (current != null)
          {
             yield return current.Value;
    
             lock (_mLock)
                if (current == _tail)
                   CopyNextChunkElement();
             current = current.Next;
          }
       }
    
       IEnumerator IEnumerable.GetEnumerator()
          => GetEnumerator();
    
    
       private void CopyNextChunkElement()
       {
    
          _isLastSourceElement = !_enumerator.MoveNext();
       
          if (_isLastSourceElement || !_predicate(_enumerator.Current))
          {
             _enumerator = null;
             _predicate = null;
          }
          else
             _tail.Next = new ChunkItem(_enumerator.Current);
    
          _tail = _tail.Next;
       }
    
       internal bool CopyAllChunkElements()
       {
          while (true)
             lock (_mLock)
             {
                if (DoneCopyingChunk)
                   return _isLastSourceElement;
    
                CopyNextChunkElement();
             }
       }
       private class ChunkItem
       {
          public readonly TSource Value;
          public ChunkItem Next;
    
          public ChunkItem(TSource value)
          {
             Value = value;
          }
       }
    }
