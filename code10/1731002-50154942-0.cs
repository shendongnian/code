    public ObservableCollection<> MyCollection
    {
        get { return _myCollection; }
        set { _myCollection = value; }
    }
    
    <ListBox ItemsSource="{Binding Path=MyCollection}" />
