    private readonly List<T> myPrivateCollection_ = new ...;
    private readonly ReadOnlyCollection<T> myPrivateCollectionView_ 
         = new ReadOnlyCollection<T>( this.myPrivateCollection_ );
    public ReadOnlyCollection<T> MyCollection {
      get { return this.myPrivateCollectionView_; }
    }
