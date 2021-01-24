    private void LeftTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine(LeftTabs.SelectedIndex);
        TabItem tabItem = e.AddedItems[0] as TabItem;
        var currentDataGrid = (DataGrid)tabItem.Content;
        Debug.WriteLine(currentDataGrid.Name);
    }
