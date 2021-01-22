    public class CustomPriorityQueue<T>  // where T need NOT be IComparable
    {
      private class PriorityQueueItem : IComparable<PriorityQueueItem>
      {
        private readonly T _item;
        private readonly int _priority:
    
        // obvious constructor, CompareTo implementation and property accessors
      }
    
      // the existing PQ implementation where the item *does* need to be IComparable
      private readonly PriorityQueue<PriorityQueueItem> _inner = new PriorityQueue<PriorityQueueItem>();
    
      public void Enqueue(T item, int priority)
      {
        _inner.Enqueue(new PriorityQueueItem(item, priority));
      }
    
      public T Dequeue()
      {
        return _inner.Dequeue().Item;
      }
    }
