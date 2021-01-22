    public ObservableCollection<string> MyStrings { get; set; }
    private ListCollectionView _listCollectionView;
    private void InitializeCollection()
    {
        MyStrings = new ObservableCollection<string>();
        _listCollectionView = CollectionViewSource.GetDefaultView(MyStrings) 
                  as ListCollectionView;
        if (_listCollectionView != null)
        {
            _listCollectionView.IsLiveSorting = true;
            _listCollectionView.CustomSort = new 
                    CaseInsensitiveComparer(CultureInfo.InvariantCulture);
        }
    }
