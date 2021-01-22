    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    
    [...]
    
    ConcurrentQueue<ListViewItem> lvItems = new ConcurrentQueue<ListViewItem>();
         private void populateListView(IEnumerable<MyClassType> myObjects)
         {
            var listOfItems = new List<ListViewItem>();
            var tasks = new List<Task>();
             // Clear the list view and refresh it
            if (myListView.InvokeRequired)
            {
                myListView.BeginInvoke(new MethodInvoker(() => myListView.Items.Clear()));
                myListView.BeginInvoke(new MethodInvoker(() => myListView.Refresh()));
            }
            else
            {
                myListView.Items.Clear();
                myListView.Refresh();
            }
            // Change the cursor to a waiting cursor (hour-glass)
            if (this.InvokeRequired)
                this.BeginInvoke(new MethodInvoker(() => this.Cursor = Cursors.WaitCursor));
            else
                this.Cursor = Cursors.WaitCursor;
            // Loop over the objects to create the list view items
            foreach (var myObj in myObjects)
                tasks.Add(Task.Factory.StartNew(() => this.createListViewItem(myObj)));
            // Wait for all the tasks to complete
            Task.WaitAll(tasks.ToArray());
            // List view item to be used as we dequeue items from the queue
            ListViewItem lvItem;
            // Loop until the queue is empty
            while (!lvItems.IsEmpty)
            {
                // Dequeue the item from the queue
                if (!lvItems.TryDequeue(out lvItem))
                    continue;
                // Add it to the local List object
                listOfItems.Add(lvItem);
            }
            // Perform a mass-add of all the list view items we created
            if (myListView.InvokeRequired)
            {
                myListView.BeginInvoke(new MethodInvoker(() => myListView.BeginUpdate()));
                myListView.BeginInvoke(new MethodInvoker(() => myListView.Items.AddRange(listOfItems.ToArray())));
                myListView.BeginInvoke(new MethodInvoker(() => myListView.EndUpdate()));
            }
            else
            {
                myListView.BeginUpdate();
                myListView.Items.AddRange(listOfItems.ToArray());
                myListView.EndUpdate();
            }
            // Change the cursor back to default, since our processing is complete
            if (this.InvokeRequired)
                this.BeginInvoke(new MethodInvoker(() => this.Cursor = Cursors.Default));
            else
                this.Cursor = Cursors.Default;
      }
     private void createListViewItem(MyClassType obj)
     {
       ListViewItem lvItem = null;
       if (obj!= null)
       {
            lvItem = new ListViewItem(obj.ToString("N"));
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem , obj.ToString("C")));
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem , obj.ToString("U")));
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem , obj.ToString("CM")));
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem , obj.ToString("L1")));
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem , obj.ToString("L2")));
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem , obj.ToString("BS")));
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem , obj.ToString("OC")));
            lvItem.Tag = obj;
     }
            // Add the created list view item to the concurrent queue for later retrieval
            if (lvItem != null)
                lvItems.Enqueue(lvItem);
        }
