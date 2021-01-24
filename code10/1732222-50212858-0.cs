    RoutedEventArgs f;
    
    private void A1TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            ContentDialog_PrimaryButtonClick (Sender, f);       
        }
    }
