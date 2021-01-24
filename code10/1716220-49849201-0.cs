    protected override void OnActivated(IActivatedEventArgs args)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame == null)
        {
            rootFrame = new Frame();
            Window.Current.Content = rootFrame;
        }
     
        string payload = string.Empty;
        if (args.Kind == ActivationKind.StartupTask)
        { 
            var startupArgs = args as StartupTaskActivatedEventArgs;
            payload = ActivationKind.StartupTask.ToString();
        }
     
        rootFrame.Navigate(typeof(MainPage), payload);
        Window.Current.Activate();
    }
