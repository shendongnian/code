    private void FocusTableRow (object sender, RoutedEventArgs e)
    {
        sender.GetType ().GetProperty ("Background").SetValue (sender, Brushes.LightGray);
        foreach (var row in feedTableRowGroup.Rows) {
            if (row != sender) {
                row.GetType ().GetProperty ("Background").SetValue (row, Brushes.White);
            }
        }
        e.Handled = true;
    }
