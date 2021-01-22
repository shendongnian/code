    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        TreeViewItem item = (TreeViewItem)treeView.SelectedItem;
        SubForm.Source = new Uri(item.Tag.ToString(), UriKind.RelativeOrAbsolute);
    }
