    protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {      
        if (e.Action == NotifyCollectionChangedAction.Remove && SelectedItem != null)
        {
            var index = Items.IndexOf(SelectedItem);
            if (index + 1 < Items.Count)
            {
                var item = Items.GetItemAt(index + 1) as TreeViewItem;
                if (item != null)
                {
                    item.IsSelected = true;
                }
            }
        }
    }
