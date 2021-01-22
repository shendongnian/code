    class MyCollection {
    
      public IEnumerable<MyObject> this[string indexer] {
        get{ return this.Where(p => p.Location == indexer); }
      }
      public IEnumerable<MyObject> this[int size] {
        get{ return this.Where(p => p.Count() == size);}
      }
    }
