    public string Token
    {
        get => _token;
        set
        {
            if (value == _token)
            { 
                return;
            }
            _token = value;
            OnPropertyChanged();
        }
    }
