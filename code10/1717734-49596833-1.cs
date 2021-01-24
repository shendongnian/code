    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        HomePage page = Window.Current.Content as HomePage;
        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (page == null)
        {
            page = new HomePage();
            Window.Current.Content = page;
        }
        if (e.PrelaunchActivated == false)
        {
            // Ensure the current window is active
            Window.Current.Activate();
        }
    }
