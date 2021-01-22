    class Report {
       [...]
       // Called when the content of an VirtualItem is needed.
       public event RetrieveVirtualItemEventHandler RetrieveVirtualItem;
       [...]
       private AddRows() {
          for (int i = 0; i < GetItemCount(); i++) 
             AddRow(GetItem(i));
       }
       private ListViewItem GetItem(n) {
          if (_listView.VirtualMode)
             return GetVirtualItem(n);
          return _listView.Items[n];
       }
        private ListViewItem GetVirtualItem(int n)
        {
            if (RetrieveVirtualItem == null)
                throw new InvalidOperationException(
                    "Delegate RetrieveVirtualItem not set when using ListView in virtual mode");
            RetrieveVirtualItemEventArgs e = new RetrieveVirtualItemEventArgs(n);
            RetrieveVirtualItem(_listView, e);
            if (e.Item != null)
            {
                return e.Item;
            }
            throw new ArgumentOutOfRangeException("n", "Not in list");
        }
       private static int GetItemsCount()
       {
          if (_listView.VirtualMode)
              return _listView.VirtualListSize;
          return _listView.Items.Count;
       }
    }
