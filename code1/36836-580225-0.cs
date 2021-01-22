    public class LimitedQueue<T> : IList<T>
    {
      public int MaxSize {get; set;}
      private Queue<T> Items = new Queue<T>();
      public void Add(T item)
      {
        Items.Enqueue(item);
        if(Items.Count == MaxSize)
        {
           Items.Dequeue();
        }
      }
      // I'll let you do the rest
    }
