    protected override void OnNavigatedTo(object sender, object args)
    {
        if(ColourSelections.TextColor != null)
        {
            //considering NavigationItem1 is the x:Name of your first NavigtionViewItem.
            NavigationItem1.Foreground = ColourSelections.TextColor;
        }
    }
