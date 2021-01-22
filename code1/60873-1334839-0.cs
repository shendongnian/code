    private void ExpandTreeViewItem(TreeViewItem tvi)
            {
                tvi.IsSelected = true;
                tvi.IsExpanded = true;
                tvi.UpdateLayout();
                _treeScroll.ScrollIntoView(tvi);
            }
