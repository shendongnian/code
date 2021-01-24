    public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
    {
        string pnsHandle = deviceToken.Description
                                      .Replace("<", string.Empty)
                                      .Replace(">", string.Empty)
                                      .Replace(" ", string.Empty)
                                      .ToUpper(); 
    
        Hub = new SBNotificationHub(Constants.ListenConnectionString, Constants.NotificationHubName);
    
        Hub.UnregisterAllAsync (pnsHandle, (error) => 
        {
            if (error != null)
            {
                System.Diagnostics.Debug.WriteLine("Error calling Unregister: {0}", error.ToString());
                return;
            }
    
            // In my use case, the tags are assigned by the server based on privileges.
            NSSet tags = null;
    
            Hub.RegisterNativeAsync(pnsHandle, tags, (errorCallback) => 
            {
                if (errorCallback != null)
                    System.Diagnostics.Debug.WriteLine("RegisterNativeAsync error: " + errorCallback.ToString());
            });
        });
    }
