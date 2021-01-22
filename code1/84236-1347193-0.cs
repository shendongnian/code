    private IEnumerable<ListViewSubItem> GetItemsFromListViewControl()
    {                      
        foreach (ListViewItem itemRow in this.loggerlistView.Items)
        {            
            for (int i = 0; i < itemRow.SubItems.Count; i++)
            {
                yield return itemRow.SubItems[i]);
            }
        }
    }
