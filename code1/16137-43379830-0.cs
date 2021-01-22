    protected override void OnStartup(object sender, StartupEventArgs e)
    {
    	DisplayRootViewFor<IMainWindowViewModel>();
    
    	Application.MainWindow.Topmost = true;
    	Application.MainWindow.Activate();
    	Application.MainWindow.Activated += OnMainWindowActivated;
    }
    
    private static void OnMainWindowActivated(object sender, EventArgs e)
    {
        var window = sender as Window;
        if (window != null)
        {
            window.Activated -= OnMainWindowActivated;
            window.Topmost = false;
            window.Focus();
        }
    }
