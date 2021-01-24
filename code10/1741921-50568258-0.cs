    protected override void OnStartup(StartupEventArgs e)
    {           
        string sMutexUniqueName = "MutexForMyApp" + Assembly.GetExecutingAssembly().GetName().Name;
    
        bool createdNew;
    
        _mutex = new Mutex(true, sMutexUniqueName, out createdNew);
    
        // App is already running! Exiting the application  
        if (!createdNew)
        {               
            MessageBox.Show("App is already running, so cannot run another instance !","MyApp",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            Application.Current.Shutdown();
        }
    
        base.OnStartup(e);
    
        //Initialize the bootstrapper and run
        var bootstrapper = new Bootstrapper();
        bootstrapper.Run();
    }
