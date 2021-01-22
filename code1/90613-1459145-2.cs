    using System.Windows.Threading;
    ...
    
    
    if (listView1.Dispatcher.Thread != Thread.CurrentThread)
    {
        listView1.Dispatcher.BeginInvoke(
            DispatcherPriority.Normal,
            new EventHandler<ListViewAddEventArgs>(AddItemToListView), sender, new object[] { e } );
        return;
    }
    listView1.Items.Add(e.File);
