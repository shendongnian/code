        private void ClearSelectedItem()
        {
            if (AssetTreeView.SelectedItem != null)
            {
                DeselectTreeViewItem(AssetTreeView.Items.Cast<TreeViewItem>());
            }
        }
