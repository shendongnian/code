    public class MySortedList<T> : IList<T> {
      private SortedList<T> _list = new SortedList<T>();
      public event EventHandler Added;
      public void Add(T value) {
        _list.Add(value);
        if ( null != Added ) {
          Added(this, EventArgs.Empty);
        }
      }
      // IList<T> implementation omitted
    }
