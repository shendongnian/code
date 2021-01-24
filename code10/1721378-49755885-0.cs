    /// <summary>
        /// Recursivly search the treeview until desired TreeViewItem is found
        /// </summary>
        /// <param name="_treeView"></param>
        /// <param name="_parent"></param>
        /// <returns></returns>
        private TreeViewItem SearchTreeView(TreeView _treeView, string _parent)
        {
            TreeViewItem foundItem = null;
            foreach (TreeViewItem item in _treeView.Items)
            {
                if (item.Header.ToString().Contains(_parent))
                {
                    foundItem = item;
                }
                else
                {
                    foundItem = SearchTreeView(item, _parent);
                }
            }
            return foundItem;
        }
        /// <summary>
        /// Recursivly search the treeviewitem until desired TreeViewItem is found
        /// </summary>
        /// <param name="_item"></param>
        /// <param name="_parent"></param>
        /// <returns></returns>
        private TreeViewItem SearchTreeView(TreeViewItem _item, string _parent)
        {
            TreeViewItem foundItem = null;
            foreach (TreeViewItem subItem in _item.Items)
            {
                if (subItem.Header.ToString().Contains(_parent))
                {
                    foundItem = subItem;
                }
                else
                {
                    foundItem = SearchTreeView(subItem, _parent);
                }
            }
            return foundItem;
        }
