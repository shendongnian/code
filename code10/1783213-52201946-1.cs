    Reachability.ReachabilityChanged += OnReachabilityChanged;
    private void OnReachabilityChanged(object sender, EventArgs args)
    {
        internetStatus = Reachability.InternetConnectionStatus();
    }
