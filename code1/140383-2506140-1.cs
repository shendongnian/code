    private object _ActiveCollection;
    public object ActiveCollection
    {
       get { return _ActiveCollection; } 
       set
       {
          _ActiveCollection = value;
          OnPropertyChanged("ActiveCollection");
       }
    }
