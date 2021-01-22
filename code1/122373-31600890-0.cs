    private readonly object _personCollectionLock;
    private ObservableCollection<Person> _personCollection;
     
    public ObservableCollection<Person> PersonCollection
    {
      get { return _personCollection; }
      set
      { 
        _personCollection = value;
        BindingOperations.EnableCollectionSynchronization(_personCollection, _personCollectionLock);
      }
