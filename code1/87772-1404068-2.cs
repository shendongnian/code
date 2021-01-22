    // assuming you had a pre-existing item
    ListViewItem item = ListView1.FindItemWithText("test");
    if (!ListView1.Items.Contains(item))
    {
        // doesn't exist, add it
    }
    
    // or you could find it by the item's text value
    ListViewItem item = ListView1.FindItemWithText("test");
    if (item != null)
    {
        // it exists
    }
    else
    {
        // doesn't exist
    }
    
    // you can also use the overloaded method to match sub items
    ListViewItem item = ListView1.FindItemWithText("world", true, 0);
