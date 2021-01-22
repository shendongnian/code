    private void treeItemExpanded(object sender, RoutedEventArgs e)
        {
            // Get the source
            var item = e.OriginalSource as TreeViewItem;
            // If the item source is a Simple TreeViewItem
            if (item == null)
            // then Nothing
            { return; }
            if (item.Name == "root")
            {
                // Load Children ( populate the treeview )
                ThreadPool.QueueUserWorkItem(delegate
                {
                    List<Server> servers = Server.GetServers();
                    Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)delegate
                    {
                        root.Items.Clear();
                        // Fill the treeview with the servers
                        root.ItemsSource = servers;
                    });
                });
            }
            // Get data from item as Folder (also works for Server)
            Folder treeViewElement = item.DataContext as Folder;
            // If there is no data
            if (treeViewElement == null)
            {
                return;
            }
            // Load Children ( populate the treeview )
            ThreadPool.QueueUserWorkItem(delegate
            {
                // Clear the Children list
                var children = treeViewElement.GetChildren();
                // Populate the treeview thanks to the bind
                Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)delegate
                {
                    treeViewElement.Children.Clear();
                    foreach (Folder folder in children)
                    {
                        treeViewElement.Children.Add(folder);
                    }
                });
            });
        }
