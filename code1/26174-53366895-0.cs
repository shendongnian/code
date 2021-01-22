        private static void DeselectTreeViewItem(IEnumerable<TreeViewItem> treeViewItems)
        {
            foreach (var treeViewItem in treeViewItems)
            {
                if (treeViewItem.IsSelected)
                {
                    treeViewItem.IsSelected = false;
                    return;
                }
                DeselectTreeViewItem(treeViewItem.Items.Cast<TreeViewItem>());
            }
        }
