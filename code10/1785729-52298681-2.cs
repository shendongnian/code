    private void LeftTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (IsLoaded)
        {
            TabItem tabItem = e.AddedItems[0] as TabItem;
            var currentDataGrid = (DataGrid)tabItem.Content;
            currentDataGrid.Measure(new Size(currentDataGrid.ActualWidth, currentDataGrid.ActualHeight));
            currentDataGrid.Arrange(new Rect(0, 0, currentDataGrid.ActualWidth, currentDataGrid.ActualHeight));
            //...
        }
    }
