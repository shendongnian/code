    private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (sender.GetType() == typeof(DataGridCell))
        {
             DataGridCell cell = sender as DataGridCell;
             cell.IsEditing = true;
        }
    }
