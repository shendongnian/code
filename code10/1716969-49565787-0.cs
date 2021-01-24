    private ICommand _detailCommand;
    public ICommand DetailCommand
    {
        get
        {
        if (_detailCommand == null)
        {
            _detailCommand = new RelayCommand(
            param => this.Execute(param),
            );
        }
        return _detailCommand;
        }
    }
    private void Execute(object param)
    {
        MessageBox.Show($"Selected CustomerId : {param.ToString()}");
    }
