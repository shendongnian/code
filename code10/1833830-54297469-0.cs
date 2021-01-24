    private void OnContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        if (args.InRecycleQueue) return;
    
        // Currently we are adding messages to the ListView.ItemSource as Activity objects
        // since this handler is called when the content changes (an item is added)
        // intercept the item as an activity and set its horizontal alignment accordingly
        Activity message = args.Item as Activity;
        args.ItemContainer.HorizontalAlignment = (message.From.Name == botHandle) ? HorizontalAlignment.Right : HorizontalAlignment.Left;
    }
