    private bool _handle = true;
    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        if (!_handle)
            return;
        bool isChecked = registry.GetValue("AppName") != null;
        _handle = false; //prevent the event handler from being invoked
        Toggle.IsChecked = isChecked;
        _handle = true; //enable the event handler again
    }
