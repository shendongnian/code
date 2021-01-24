    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        ...
        
    	Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
    	Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s,a) =>
    	{
    		
    		if (Frame.CanGoBack)
    		{
    			Frame.GoBack();
    			a.Handled = true;
    		}
    	}
        ...
    }
