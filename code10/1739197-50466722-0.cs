    private SolidColorBrush _background;
    public SolidColorBrush Background
    {
        get
        {
            return _background;
        }
        set
        {
            _background = value;
            OnPropertyChanged();
        }
    }
