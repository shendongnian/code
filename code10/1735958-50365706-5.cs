     protected async override void OnLaunched(LaunchActivatedEventArgs e)
     {
         using (var db = new BloggingContext())
         {
             //db.Database.EnsureCreated();
             bool isExist = await IsFileExisted("db1.db");
             if (!isExist)
             {
                 db.Database.Migrate();
             }
    
         }
    
         Frame rootFrame = Window.Current.Content as Frame;
    
         // Do not repeat app initialization when the Window already has content,
         // just ensure that the window is active
         if (rootFrame == null)
         {
             // Create a Frame to act as the navigation context and navigate to the first page
             rootFrame = new Frame();
    
             rootFrame.NavigationFailed += OnNavigationFailed;
    
             if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
             {
                 //TODO: Load state from previously suspended application
             }
    
             // Place the frame in the current Window
             Window.Current.Content = rootFrame;
         }
         ...
    }
