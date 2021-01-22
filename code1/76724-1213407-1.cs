    public class FixedSizeList<T> : IList<T> {
      private List<T> _list = new List<T>();
      private int _capacity = 100;
    
      public void Add(T value) {
        _list.Add(value);
        while ( _list.Count > _capacity ) {
          _list.RemoveAt(0);
        }
      }
      // Rest omitted for brevity
    }
