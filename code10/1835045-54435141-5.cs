    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Set minimum width for column1 based on content
        item1Column.Width = new DataGridLength(1, DataGridLengthUnitType.SizeToCells);
        item1Column.MinWidth = item1Column.ActualWidth;
        ResizeColumns();
    }
