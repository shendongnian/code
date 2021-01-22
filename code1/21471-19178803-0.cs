    private void DataBoundMenuItem_Click(object sender, RoutedEventArgs e)
    {
        // get menu item with ItemsSource bound
        var myItemsMenuItems = sender as MenuItem; 
        // get submenu clicked item constructed from MyMenuItems collection
        var myItemsMenuSubItem = e.OriginalSource as MenuItem; 
        // get underlying MyMenuItems collection item
        var o = myItemsMenuItems
            .ItemContainerGenerator
            .ItemFromContainer(myItemsMenuSubItem);
        // convert to MyMenuItems type ... in our case string
        var itemObj = o as (string);
        // TODO some processing
    }
