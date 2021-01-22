    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        // code to lauch after validation
    }
    
    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            TextBox_LostFocus(sender, null);
        }
    }
