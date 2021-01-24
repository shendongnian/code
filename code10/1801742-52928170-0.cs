    protected override void OnFileActivated(FileActivatedEventArgs e)
    {
        Frame rootFrame = CreateRootFrame();
        if (rootFrame.Content == null)
        {
            if (!rootFrame.Navigate(typeof(MainPage)))
            {
                throw new Exception("Failed to create initial page");
            }
        }
        var p = rootFrame.Content as MainPage;
        p.NavigateToPageWithParameter(2, e);
        // Ensure the current window is active
        Window.Current.Activate();
    }
