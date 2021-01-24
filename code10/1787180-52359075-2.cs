    private void NavView_Loaded(object sender, object args)
    {
        SolidColorBrush DefaultTextColour = Application.Current.Resources["DefaultTextColour"] as SolidColorBrush;    
        foreach (var item in NavView.MenuItems.OfType<NavigationViewItem>())
        {
            item.Foreground = DefaultTextColour;
        } 
    }
