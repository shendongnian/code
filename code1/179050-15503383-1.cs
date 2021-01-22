    ObservableCollection<SolidColorBrush> Colors
    {
        get
        {
            if (_colors == null)
                LoadColors();
    
            return _colors;
        }
        set { ... }
    }
    
    void LoadColors()
    {
        // Initialization logic here
    }
