    // custom override class over the list box so we can create an event when items are added
    public class ListBoxWithEvents : ListBox
    {
        // the event you need to bind to know when items are added
        public event EventHandler<ListBoxItemEventArgs> ItemAdded;
        // method to call to add items instead of lst.Items.Add(x);
        public void AddItem(object data)
        {
            // add the item normally to the internal list
            var index = Items.Add(data);
            // invoke the event to notify the binded handlers
            InvokeItemAdded(index);
        }
      
        public void InvokeItemAdded(int index)
        {
            // invoke the event if binded anywhere
            ItemAdded?.Invoke(this, new ListBoxItemEventArgs(index));
        }
    }
    // basic event handler that will hold the index of the item added
    public class ListBoxItemEventArgs : EventArgs
    {
        public int Index { get; set; } = -1;
        public ListBoxItemEventArgs(int index)
        {
            Index = index;
        }       
    }
