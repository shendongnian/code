    Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
    
    private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
    {
        if ( AppFrame.CanGoBack )
        {
           AppFrame.GoBack();
           e.Handled = true;
        }
    }
