    private PointStyleModel _selectedPointStyle;
    public PointStyleModel SelectedPointStyle
    {
        get => _selectedPointStyle;
        set
        {
            _selectedPointStyle = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(PointStyleColor)); 
            OnPropertyChanged(nameof(PointStyleSize)); 
        }
     }
