    public ViewModel()
    {
        MyCommand = new RelayCommand(MyCommandMethod, MyCanExecutePredicate);
    }
    private bool MyCanExecutePredicate( object commandParameter )
    {
        // TODO: decide whether or not MyCommandMethod is allowed to execute right now
    }
