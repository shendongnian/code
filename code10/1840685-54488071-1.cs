        private void TvMain_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            string result = "";
            TreeView tree = (TreeView) sender;
            TreeViewItem item = (TreeViewItem) tree.SelectedItem;
            result = item.Header.ToString();
            while (item.Parent != null && item.Parent is TreeViewItem)
            {
                item = (TreeViewItem)item.Parent;
                result = item.Header.ToString() + " \\ " + result;
            }
            MessageBox.Show(result);
        }
