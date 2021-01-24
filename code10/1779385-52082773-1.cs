    public class IdList<T> where T : IdList<T>.Item {
      List<T> List = new List<T>();
    
      [System.Runtime.CompilerServices.IndexerName("TheItem")]
      public T this[int id] {
        get => List[id];
        set { }
      }
    
      public class Item {
        public int id;
        // Not shown: id used for equality and hash.
      }
    }
