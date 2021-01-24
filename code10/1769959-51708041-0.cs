    private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.N && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
        {
            Keyboard.Focus(SearchTextBox);
            SearchTextBox.Dispatcher.BeginInvoke(new Action(() =>
            {
                SearchTextBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }), System.Windows.Threading.DispatcherPriority.Background);
            e.Handled = true;
        }
    }
