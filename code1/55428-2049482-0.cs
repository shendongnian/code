    internal void AddressChangedCallback(object sender, EventArgs e)
    {
        // Check for NetworkConnectivity
        _isInternetConnectionActive = new NetworkConnectivity().IsInternetConnected; 
    }
