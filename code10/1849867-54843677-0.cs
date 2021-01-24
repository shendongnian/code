    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        var textbox = (TextBox)sender;
        var isNumber = int.TryParse(textbox.Text, out var num);
        if (!isNumber)
        {
            //not validated
            return; 
        }
    
        if (!(num > 0 && num < 256)) 
        {
           //not validated
           return;
        }
    
        //valid 
    }
    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            // call the LostFocus event to validate the TextBox
            ((TextBox)sender).RaiseEvent(new RoutedEventArgs(TextBox.LostFocusEvent));
        }
    }
