    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        // code to lauch after validation
    }
    
    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            // give the focus to another control to call the LostFocus event
            this.AnotherControl.Focus();
            // or directly call the EventHandler
            TextBox_LostFocus(sender, null);
        }
    }
