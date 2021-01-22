    public class MyListView : ListView
    {
        public void AddItem(ListViewItem item)
        {
            Items.Add(item);
            if (ItemAdded != null)
                ItemAdded.Invoke(this, new ItemsAddedArgs(item));
        }
        public EventHandler<ItemsAddedArgs> ItemAdded;
    }
    public class ItemsAddedArgs : EventArgs
    {
        public ItemsAddedArgs(ListViewItem item)
        {
            Item = item;
        }
        public object Item { get; set; }
    }
