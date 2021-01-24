    private bool isconnect;
    public bool IsConnect
    {
        get { return isconnect; }
        set { SetProperty(ref isconnect, value); }
    }
    
    Constructor()
    {
    
        //Assign IsConnected when entering the Constructor
        IsConnect = CrossConnectivity.Current.IsConnected; //Don't know if you are using this plugin
    
        MessagingCenter.Subscribe<App, bool>(this, "Internet", (sender, arg) =>
            {
                if(IsConnect != arg)
                {
                    IsConnect = arg;
                    LoadSessions();
                }            
            });
        LoadSessions();
    }
