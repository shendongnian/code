    private void TipsGrid_ItemClick(object sender, ItemClickEventArgs e)
    {
        ConnectedAnimation animation = null;
    
        // Get the collection item corresponding to the clicked item.
        var container = collection.ContainerFromItem(e.ClickedItem) as GridViewItem;
        if (container != null)
        {
            // Stash the clicked item for use later. We'll need it when we connect back from the detailpage.
            _storedItem = Convert.ToInt32(container.Content);
    
            // Prepare the connected animation.
            // Notice that the stored item is passed in, as well as the name of the connected element. 
            // The animation will actually start on the Detailed info page.
            animation = collection.PrepareConnectedAnimation("forwardAnimation", _storedItem, "connectedElement");
    
        }
    
        SmokeGrid.Visibility = Visibility.Visible;
       // SmokeGrid.DataContext = e.ClickedItem;
        animation.TryStart(destinationElement);
    }
