    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        CheckBox checkBox = (CheckBox) e.Source;
        DataRow row = ((DataRowView) checkBox.DataContext).Row;
        bool isChecked = checkBox.IsChecked ?? false;
    }
