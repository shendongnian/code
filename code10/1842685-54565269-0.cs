    protected override void OnStart ()
    {
        Distribute.ReleaseAvailable = OnReleaseAvailable;
        AppCenter.Start("android=<appsecret>;", typeof(Analytics), typeof(Crashes), typeof(Distribute));
        Analytics.SetEnabledAsync(true);
    }
    
    bool OnReleaseAvailable(ReleaseDetails releaseDetails)
    {
         ... 
    }
