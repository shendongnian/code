    private int? _id;
    public int? ID
    {
        get { return _id; }
        set
        {
            _id = value;
            DelegateCommand<int?> command = ((SomeClass)CalcEditView.DataContext).Add;
            command.RaiseCanExecuteChanged();
        }
    }
