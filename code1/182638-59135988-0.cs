    get { return _isButtonEnabled; }
    set
    {
        if (_isButtonEnabled == value)
        {
            return;
        }
        _isButtonEnabled = value;
        OnPropertyChanged("IsButtonEnabled");
    }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
