    private ICommand _doSomething;
    
    public ICommand DoSomething
    {
        get
        {
            if (_doSomething == null)
            {
                _doSomething = new DelegateCommand(
                    () =>
                    {
                        ICollectionView view = CollectionViewSource.GetDefaultView(Items);
                        object selected = view.CurrentItem;
                        DoSomethingWithItem(selected);
                    });
            }
            return _doSomething;
        }
    }
