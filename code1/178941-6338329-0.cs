    var itemContainer = listBox.ItemContainerGenerator.ContainerFromIndex(index) as ListBoxItem;
    // or: 
    var itemContainer = listBox.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
    
    var viewer = itemContainer.ContentTemplate.FindName("DocV", itemContainer) as DocumentViewer;
    // Do stuff with viewer
