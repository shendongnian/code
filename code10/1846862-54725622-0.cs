    public async Task<string> MakeWebRequest()
    {
        if(!CrossConnectivity.Current.IsConnected)
        {
          //You are offline, notify the user
          return null;
        }
    
        //Make web request here
    }
