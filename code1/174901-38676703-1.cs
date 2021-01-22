     public static async void PopulateListView<T>(ListView listView, Func<T, ListViewItem> func, 
            IEnumerable<T> objects, IProgress<int> progress) where T : class, new()
        {
            if (listView != null && listView.IsHandleCreated)
            {
                var conQue = new ConcurrentQueue<ListViewItem>();
                // Clear the list view and refresh it
                if (listView.InvokeRequired)
                {
                    listView.BeginInvoke(new MethodInvoker(() =>
                        {
                            listView.BeginUpdate();
                            listView.Items.Clear();
                            listView.Refresh();
                            listView.EndUpdate();
                        }));
                }
                else
                {
                    listView.BeginUpdate();
                    listView.Items.Clear();
                    listView.Refresh();
                    listView.EndUpdate();
                }
                // Loop over the objects and call the function to generate the list view items
                if (objects != null)
                {
                    int objTotalCount = objects.Count();
                    foreach (T obj in objects)
                    {
                        await Task.Run(() =>
                            {
                                ListViewItem item = func.Invoke(obj);
                                if (item != null)
                                    conQue.Enqueue(item);
                                if (progress != null)
                                {
                                    double dProgress = ((double)conQue.Count / objTotalCount) * 100.0;
                                    if(dProgress > 0)
                                        progress.Report(dProgress > int.MaxValue ? int.MaxValue : (int)dProgress);
                                }
                            });
                    }
                    // Perform a mass-add of all the list view items we created
                    if (listView.InvokeRequired)
                    {
                        listView.BeginInvoke(new MethodInvoker(() =>
                            {
                                listView.BeginUpdate();
                                listView.Items.AddRange(conQue.ToArray());
                                listView.Sort();
                                listView.EndUpdate();
                            }));
                    }
                    else
                    {
                        listView.BeginUpdate();
                        listView.Items.AddRange(conQue.ToArray());
                        listView.Sort();
                        listView.EndUpdate();
                    }
                }
            }
            if (progress != null)
                progress.Report(100);
        }
