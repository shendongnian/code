    private string _buttonUpdateVisibility;
    public string ButtonUpdateVisibility
    {
        get => _buttonUpdateVisibility;
        set
        {
            _buttonUpdateVisibility= value;
            OnPropertyChanged(nameof(ButtonUpdateVisibility));
        }
    }
