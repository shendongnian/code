    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        SolidColorBrush myColor = Application.Current.Resources["DefaultTextColour"] as SolidColorBrush;
        if (ColourSelections.TextColour != null)
        {
            myColor = ColourSelections.TextColour;
        }
        foreach(var item in NavView.MenuItems)
        {
            if(item is NavigationViewItem)
            {
                item.Foreground = myColor;
            }
        }
    }
