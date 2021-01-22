        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvi = e.OriginalSource as TreeViewItem;
            if (tvi != null)
            {
                MessageBox.Show(string.Format("TreeNode '{0}' was expanded", tvi.Header));
            }
        }
