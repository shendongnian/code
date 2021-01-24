    public ICommand Grabproxies { get; set; } = new RelayCommand(CreateProxy, true);
    
    
    private void CreateProxy(object param)
    {
        Proxies.Add(pds.GrabProxy());
    }
