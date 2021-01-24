    //private Field
    private SolidColorBrush _abColor = new SolidColorBrush(Colors.Green);
    //Public Property which the XAML binds to
    public SolidColorBrush ABColor
    {
        get { return _abColor; }
        set
        {
            _abColor = value;
            OnPropertyChanged();
        }
    }
