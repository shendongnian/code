    TreeViewItem item = m_tree.ItemContainerGenerator.ContainerFromItem(stack.Pop()) as TreeViewItem;
    while(item != null && (stack.Count > 0))
    {
        item = item.ItemContainerGenerator.ContainerFromItem(stack.Pop()) as TreeViewItem;
    }
    // Force this item to be selected, and set focus
    item.IsSelected = true;
    item.Focus();
