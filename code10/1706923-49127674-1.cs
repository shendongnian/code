    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
    
        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (rootFrame == null)
        {
            ...
     
            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
    
            _rootFrame = rootFrame;
            SetupAppBarBackButton();
        }
        ...
    }
