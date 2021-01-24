    private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            rootFrame.Navigate(typeof(SettingsPage));
            NavView.Header = "Settings";
        }
        else
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            NavView_Navigate(item);
            //just example, maybe you want to Content or something else
            NavView.Header = item.Tag.ToString(); 
        }
    }
