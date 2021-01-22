      public interface IContextStack
      {
        IDisposable Push(object item);
        object Pop();
        object Peek();
        void Clear();
        int Count { get; }
        IEnumerable<object> Items { get; }
      }
