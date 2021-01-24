    private void OnItemInvoked(NavigationViewItemInvokedEventArgs args)
    {
        if (args.IsSettingsInvoked)
        {
            NavigationService.Navigate(typeof(SettingsViewModel).FullName);
            return;
        }
    
        var item = _navigationView.MenuItems
                        .OfType<NavigationViewItem>()
                        .First(menuItem => (string)menuItem.Content == (string)args.InvokedItem);
        var pageKey = item.GetValue(NavHelper.NavigateToProperty) as string;
        NavigationService.Navigate(pageKey);
    }
