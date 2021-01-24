    private string _title;
    public string Title
    {
        get { return _title; }
        set { _title = value; OnPropertyChanged(); }
    }
