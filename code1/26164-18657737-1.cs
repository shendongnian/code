    public bool Select(TreeViewItem item, object select) // recursive function to set item selection in treeview
    {
        if (item == null)
            return false;
        TreeViewItem child = item.ItemContainerGenerator.ContainerFromItem(select) as TreeViewItem;
        if (child != null)
        {
            child.IsSelected = true;
            return true;
        }
        foreach (object c in item.Items)
        {
            bool result = Select(item.ItemContainerGenerator.ContainerFromItem(c) as TreeViewItem, select);
            if (result == true)
                return true;
        }
        return false;
    }
