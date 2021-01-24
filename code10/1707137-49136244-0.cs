    private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
            e.Handled = true;
        }
    }
