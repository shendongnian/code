                ThreadPool.QueueUserWorkItem(delegate
                {
                    List<Server> servers = new List<Server>();
                    servers = Server.GetServers();
                    this.Dispatcher.Invoke((Action)delegate
                    {
                        item.Items.Clear();
                        // Fill the treeview with the servers
                        item.ItemsSource = servers;
                    });
                });
