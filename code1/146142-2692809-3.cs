    private void ShowHidePhoto(object sender, RoutedEventArgs e)
    {
    	DataHolder dh = (DataHolder)((Button)sender).Tag;
    	dh.Visible = dh.Visible == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        // reset height here....
    }
