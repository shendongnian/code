    private void FocusTreeViewNode(MenuItem node)
    {
        if (node == null)
            return;
          
        var treeViewItem = GetTreeViewItem(tView, node);
        treeViewItem?.BringIntoView();
    }
    public static TreeViewItem GetTreeViewItem(ItemsControl container, object item)
    {
        if (container == null)
            throw new ArgumentNullException(nameof(container));
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        if (container.DataContext == item)
            return container as TreeViewItem;
        if (container is TreeViewItem && !((TreeViewItem)container).IsExpanded)
        {
            container.SetValue(TreeViewItem.IsExpandedProperty, true);
        }
        container.ApplyTemplate();
        if (container.Template.FindName("ItemsHost", container) is ItemsPresenter itemsPresenter)
        {
            itemsPresenter.ApplyTemplate();
        }
        else
        {
            itemsPresenter = FindVisualChild<ItemsPresenter>(container);
            if (itemsPresenter == null)
            {
                container.UpdateLayout();
                itemsPresenter = FindVisualChild<ItemsPresenter>(container);
            }
        }
        var itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);
        var children = itemsHostPanel.Children;
        var virtualizingPanel = itemsHostPanel as VirtualizingPanel;
        for (int i = 0, count = container.Items.Count; i < count; i++)
        {
            TreeViewItem subContainer;
            if (virtualizingPanel != null)
            {
                virtualizingPanel.BringIndexIntoViewPublic(i);
                subContainer = (TreeViewItem)container.ItemContainerGenerator.ContainerFromIndex(i);
            }
            else
            {
                subContainer = (TreeViewItem)container.ItemContainerGenerator.ContainerFromIndex(i);
                subContainer.BringIntoView();
            }
            if (subContainer != null)
            {
                TreeViewItem resultContainer = GetTreeViewItem(subContainer, item);
                if (resultContainer != null)
                    return resultContainer;
                subContainer.IsExpanded = false;
            }
        }
        return null;
    }
    private static T FindVisualChild<T>(Visual visual) where T : Visual
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
        {
            if (VisualTreeHelper.GetChild(visual, i) is Visual child)
            {
                if (child is T item)
                    return item;
                item = FindVisualChild<T>(child);
                if (item != null)
                    return item;
            }
        }
        return null;
    }
