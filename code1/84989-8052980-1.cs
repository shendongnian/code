    private static void fe_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var fe = (FrameworkElement)sender;
        if (fe.IsEnabled && (bool)((FrameworkElement)sender).GetValue(IsFocusedProperty))
        {
            fe.IsEnabledChanged -= fe_IsEnabledChanged;
            fe.Focus();
        }
    }
