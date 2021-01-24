    private async void DoExecuteGetIpCommand()
    {
        _isIndeterminate = true;
        //Tell the UI that something changed...
        OnPropertyChanged(nameof(IsIndeterminate));
        try
        {                
            _errorOccured = false;
            _ipAdrress = await getPublicIP.GetIPAddressAsync();//time consuming method.
        }
        finally
        {
            _isIndeterminate = false;
        }
        if (await getPublicIP.ExceptionOccursAsync() == true)
        {
            _errorOccured = true;
        }
        OnPropertyChanged(nameof(IsIndeterminate));
        OnPropertyChanged(nameof(IpAddress));
        OnPropertyChanged(nameof(IpForeground));
        OnPropertyChanged(nameof(IpFontWeight));            
    }
