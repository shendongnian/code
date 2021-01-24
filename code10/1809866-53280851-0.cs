    NetworkReachability _defaultRouteReachability;
    public override void WindowDidLoad()
    {
       if (_defaultRouteReachability == null)
       {
          _defaultRouteReachability = new NetworkReachability("https://example.com");
          _defaultRouteReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
          _defaultRouteReachability.SetNotification(HandleNotification);
       }
    }
    
    void HandleNotification(NetworkReachabilityFlags flags)
    {
       //Handle your actions here.
    }
