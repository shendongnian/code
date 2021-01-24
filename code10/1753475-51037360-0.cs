    private RelayCommand _enableCmd;
    public RelayCommand Enable => _enableCmd ?? (_enableCmd = new RelayCommand(doEnable, x => _isEnabled));
    private bool _isEnabled;
    public string DataText { get; set; }
    protected void doEnable(object obj)
    {
        _isEnabled = true;
        Enable.RaiseCanExecuteChanged();
        DataText = "Clicked";
        OnPropertyChange(nameof(DataText));
    }
