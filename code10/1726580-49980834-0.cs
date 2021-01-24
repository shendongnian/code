    private bool _handleEvents;
    private void MyWindow_Loaded(object sender, RoutedEventArgs e)
    {
        RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        _handleEvents = false;
        if (rk.GetValue("Z") == null)
        {
            Toggle.IsChecked = false;
        }
        else
        {
            Toggle.IsChecked = true;
        }
        _handleEvents = true;
    }
    private void Toggle_Checked(object sender, RoutedEventArgs e)
    {
        if (!_handleEvents)
            return;
        RegistryKey rkRegistryKey = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        rkRegistryKey.SetValue("Z", System.Reflection.Assembly.GetExecutingAssembly().Location);
    }
    private void Toggle_UnChecked(object sender, RoutedEventArgs e)
    {
        if (!_handleEvents)
            return;
        RegistryKey rkRegistryKey = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        rkRegistryKey.DeleteValue("Z", false);
    }
