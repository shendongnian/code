    private SubCategory _selSubCategories;
    public SubCategory selSubCategories
    {
        get { return _selSubCategories; }
        set
        {
            _selSubCategories = value;
            OnPropertyChanged(nameof(selSubCategories));
        }
    }
