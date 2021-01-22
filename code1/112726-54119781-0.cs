     private void ExpandAllNodes(TreeViewItem treeItem)
        {
            treeItem.IsExpanded = true;
            foreach (var childItem in treeItem.Items.OfType<TreeViewItem>())
            {
                ExpandAllNodes(childItem);
            }
        }
