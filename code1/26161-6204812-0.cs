        /// <summary>
        /// Selects the tree view item.
        /// </summary>
        /// <param name="Collection">The collection.</param>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        private TreeViewItem SelectTreeViewItem(ItemCollection Collection, String Value)
        {
            if (Collection == null) return null;
            foreach(TreeViewItem Item in Collection)
            {
                /// Find in current
                if (Item.Header.Equals(Value))
                {
                    Item.IsSelected = true;
                    return Item;
                }
                /// Find in Childs
                if (Item.Items != null)
                {
                    TreeViewItem childItem = this.SelectTreeViewItem(Item.Items, Value);
                    if (childItem != null)
                    {
                        Item.IsExpanded = true;
                        return childItem;
                    }
                }
            }
            return null;
        }
