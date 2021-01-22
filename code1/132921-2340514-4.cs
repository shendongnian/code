    private static void CopySelectedItems(ListView source, ListView target)
    {
        foreach (ListViewItem item in source.SelectedItems)
        {
            ListViewItem clone = (ListViewItem)item.Clone();
            target.Items.Insert(GetInsertPosition(clone, target), clone); ;
        }
    }
    
    private static int GetInsertPosition(ListViewItem item, ListView target)
    {
        const int compareColumn = 1;
        foreach (ListViewItem targetItem in target.Items)
        {
            if (targetItem.SubItems[compareColumn].Text.CompareTo(item.SubItems[compareColumn].Text) > 0)
            {
                return targetItem.Index;
            }
        }
        return target.Items.Count;
    }
