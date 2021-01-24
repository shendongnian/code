    private void OnPreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        if (e.Command == DataGrid.DeleteCommand)
        {
            DatabaseItems selectedItem = dtgMainItems.SelectedItem as DatabaseItems;
            if (selectedItem != null && !selectedItem.IsDeleteEnabled)
                e.Handled = true;
        }
    }
