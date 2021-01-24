    private void SetupAppBarBackButton()
    {
        _rootFrame.Navigated += RootFrame_Navigated;
        SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
    }
    
    private void App_BackRequested(object sender, BackRequestedEventArgs e)
    {
        if (_rootFrame.CanGoBack)
        {
            _rootFrame.GoBack();
        }
    }
    
    private void RootFrame_Navigated(object sender, NavigationEventArgs e)
    {
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            _rootFrame.CanGoBack
               ? AppViewBackButtonVisibility.Visible
               : AppViewBackButtonVisibility.Collapsed;
    }
