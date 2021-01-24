    private void checkBoxcaja_Checked(object sender, RoutedEventArgs e)
    {
        checkBoxbanderola.IsEnabled = false;
        checkBoxletra.IsEnabled = false;
    }
    
    private void checkBoxcaja_Unchecked(object sender, RoutedEventArgs e)
    {
        checkBoxbanderola.IsEnabled = true;
        checkBoxletra.IsEnabled = true;
    }
