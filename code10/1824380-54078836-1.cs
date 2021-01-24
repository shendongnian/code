    private void TabControl_OnDragEnter(object sender, DragEventArgs e)
    {
        // Just a sanity check - we need a Visual here
        if (!(e.OriginalSource is Visual v))
        {
            return;
        }
        // DragablzItems will represent our TabItems, so we search for those
        var item = GetParentOfType<DragablzItem>(v);
        // DragablzItem.Content should contain our original TabItem
        if (item != null && item.Content is TabItem ti)
        {
            ti.IsSelected = true;
        }
    }
