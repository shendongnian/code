    private void cmMetadata_Click(object sender, RoutedEventArgs e)
    {
        MenuItem menu = sender as MenuItem;
        ListViewItem lvi = lvResources.ItemContainerGenerator.ContainerFromItem(menu.DataContext) as ListViewItem;
    }
