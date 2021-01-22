    private void myComboBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource.GetType() != typeof(ComboBoxItem))
        {
            Title = "Got " + DateTime.Now;
        }
    }
    
    private void myComboBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource.GetType() != typeof(ComboBoxItem))
        {
            Title = "Lost " + DateTime.Now;
        }
    }
