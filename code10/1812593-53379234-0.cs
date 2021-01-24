    private InfiniteScrollCollection<Product_Search> _items;
    public InfiniteScrollCollection<Product_Search> Items 
    { 
        get { return _items; }
        set
        {
            _items = value;
            OnPropertyChanged();
        }
    }
