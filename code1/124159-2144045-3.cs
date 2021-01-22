    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        Button _btn = sender as Button;
        int _row = (int)_btn.GetValue(Grid.RowProperty);
        int _column = (int)_btn.GetValue(Grid.ColumnProperty);
        MessageBox.Show(string.Format("Button clicked at column {0}, row {1}", _column, _row));
    }
