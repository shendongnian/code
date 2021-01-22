    private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            e.Handled = true;
            var TabKey = new KeyEventArgs(e.KeyboardDevice, e.InputSource, e.Timestamp, Key.Tab);
            TabKey.RoutedEvent = Keyboard.KeyDownEvent;
            InputManager.Current.ProcessInput(TabKey);
        }
    }
