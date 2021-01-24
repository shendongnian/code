    private void MenuFlyout_Opened(object sender, object e)
    {
        Window.Current.Content.PreviewKeyDown += Content_PreviewKeyDown;
    }
    private void MenuFlyout_Closed(object sender, object e)
    {
        Window.Current.Content.PreviewKeyDown -= Content_PreviewKeyDown;
    }
    private void Content_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
    {
      
        if(e.Key == VirtualKey.D)
        {
            //delete current item
        }
    }
