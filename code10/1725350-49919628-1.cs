    protected override async void OnLaunched(LaunchActivatedEventArgs e)
    {
        ...
    
        var appManager = AppManager.Instance;
        await appManager.InitializeAsync();
        Xamarin.Forms.Forms.Init(e);
    
        ...
    }
