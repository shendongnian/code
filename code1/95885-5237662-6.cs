    private void myComboBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource.GetType() != typeof(ComboBoxItem))
        {
            Trace.WriteLine("Got " + DateTime.Now);
        }
    }
    
    private void myComboBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource.GetType() != typeof(ComboBoxItem))
        {
            Trace.WriteLine("Lost " + DateTime.Now);
        }
    }
