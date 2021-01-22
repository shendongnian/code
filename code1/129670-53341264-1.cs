        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeView = (TreeView)sender;
            var command = (ICommand)treeView.Tag;
            TreeViewItem selectedItem = (TreeViewItem)treeView.SelectedItem;
            if (selectedItem.Tag != null)
            {
                command.Execute(selectedItem.Tag);
            }
        }
