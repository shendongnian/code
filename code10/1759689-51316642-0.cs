    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        var container = MainGridStations.ContainerFromIndex(0);
        GridViewItem gridViewItem = container as GridViewItem;
        gridViewItem.Background = new SolidColorBrush(Colors.Green);
    }
    
    //get the item here
    private void GridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var container = MainGridStations.ContainerFromIndex(0);
        GridViewItem gridViewItem= container as GridViewItem;
        gridViewItem.Background = new SolidColorBrush(Colors.Red);
        //var presenter = VisualTreeHelper.GetChild(container, 0) as GridViewItem;
    }
