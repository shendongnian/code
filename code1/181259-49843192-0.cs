    private void TreeViewItemDoubleClicked( object sender, RoutedEventArgs e )
    {
        // Make sure the event has never been handled first
        if (bubblingBulkwark)
            return;
        // Get the specific tree view item that was double clicked
        TreeViewItem treeViewItem = sender as TreeViewItem;
    
        // not null?
        if( null != treeViewItem )
        {
             // Switch expanded state
             if( true == treeViewItem.IsExpanded )
             {
                 treeViewItem.IsExpanded = false;
             }
             else
             {
                 treeViewItem.IsExpanded = true;
             }
    
             // Raise bulkwark
             bubblingBulkwark = true;
        }
    }
