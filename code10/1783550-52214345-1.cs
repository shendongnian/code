    public App()
    {
        App.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    
        if (MessageBox.Show("Continue?", "", MessageBoxButton.YesNo) == MessageBoxResult.No)
            App.Current.Shutdown(0);
    }
