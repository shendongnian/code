    private void Conllection_ItemClick(object sender, ItemClickEventArgs e)
    {
        ConnectedAnimation animation = null;
        var container = collection.ContainerFromItem(e.ClickedItem) as GridViewItem;
        if(container != null)
        {
            _storedItem = container.Content;
            animation = collection.PrepareConnectedAnimation("forwardAnimation", _storedItem, "connectedElement");
        }
        SmokeGrid.Visibility = Visibility.Visible;
       // pass the item DataContext.
        SmokeGrid.DataContext = e.ClickedItem;
        animation.TryStart(destinationElement);
    }
 
