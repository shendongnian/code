    public IEnumerable<T> MyCollection {
      get {
        foreach( T item in this.myPrivateCollection_ )
          yield return item;
      }
    }
