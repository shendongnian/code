    public ViewModel()
    {
        Recipients = new ObservableCollection<Recipient>();
        recipientsView= CollectionViewSource.GetDefaultView(Recipients);
    
        // rest of code not shown
    }
