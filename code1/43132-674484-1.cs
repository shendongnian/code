    public static class TreeViewItemExtensions
    {
        public static TreeViewItem GetParentItem(this TreeViewItem item)
        {
            FrameworkElement elem = item;
            while (elem.Parent != null)
            {
                var tvi = elem.Parent as TreeViewItem;
                if (tvi != null)
                    return tvi;
                elem = elem.Parent as FrameworkElement;
            }
            return null;
        }
    }
