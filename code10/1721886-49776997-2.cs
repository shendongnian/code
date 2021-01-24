    private void Button_Click(object sender, RoutedEventArgs e)
    {
        foreach (var item in tv.Items)
        {
            TreeViewItem tvi = tv.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
            tvi.IsExpanded = true;
            tvi.UpdateLayout();
            RecurseItem(tvi);
        }
    }
    private bool gotTheItem = false;
    private void RecurseItem(TreeViewItem item)
    {
        foreach (var subItem in item.Items)
        {
            TreeViewItem tvi = item.ItemContainerGenerator.ContainerFromItem(subItem) as TreeViewItem;
            // do something
            if (!gotTheItem)
            {
                RecurseItem(tvi);
            }
        }
    }
