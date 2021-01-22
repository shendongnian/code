    private readonly List<T> myPrivateCollection_ = new ...;
    private ReadOnlyCollection<T> myPrivateCollectionView_;
    public ReadOnlyCollection<T> MyCollection {
      get {
        if( this.myPrivateCollectionView_ == null ) { /* lazily initialize view */ }
        return this.myPrivateCollectionView_;
      }
    }
