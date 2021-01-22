    private void SetFocusOnGrid(DataGrid grid, int index)
    {
        grid.ScrollIntoView(grid.Items.GetItemAt(index));
        grid.SelectionMode = DataGridSelectionMode.Single;
        grid.SelectionUnit = DataGridSelectionUnit.FullRow;
        grid.SelectedIndex = index;
    
        DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
        row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
    }  
  
