    internal static class ListViewItemCollectionExtender
    {
        internal static void AddWithTextAndSubItems(
                                       this ListView.ListViewItemCollection col, 
                                       string text, params string[] subItems)
        {
            var item = new ListViewItem(text);
            foreach (var subItem in subItems)
            {
                item.SubItems.Add(subItem);
            }
            col.Add(item);
        }
    }
