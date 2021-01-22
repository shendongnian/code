    private bool returnedFocus = false;
    
    private void myComboBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource.GetType() != typeof(ComboBoxItem) && !returnedFocus)
        {
            //Your code.
        }
    }
    
    private void myComboBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource.GetType() != typeof(ComboBoxItem))
        {
            ComboBox cb = (ComboBox)sender;
            returnedFocus = cb.IsDropDownOpen;
        }
    }
