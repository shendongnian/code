            private void listJobs_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int index = listJobs.IndexFromPoint(e.Location);
                    if (index != ListBox.NoMatches)
                    {
                        listJobs.SelectedIndex = index;
                        Job job = (Job)listJobs.Items[index];
                        ContextMenu cm = new ContextMenu();
                        AddMenuItem(cm, "Run", QueueForRun, job).Enabled = !job.Pending;
                        AddMenuItem(cm, "Cancel run", CancelQueueForRun, job).Enabled = (job.State == JobState.Pending || job.State == JobState.Running);
                        AddMenuItem(cm, "Open folder", OpenFolder, job);
                        cm.Show(listJobs, e.Location);
                    }
                }
            }
            private MenuItem AddMenuItem(ContextMenu cm, string text, EventHandler handler,     object context)
            {
                MenuItem item = new MenuItem(text, handler);
                item.Tag = context;
                cm.MenuItems.Add(item);
                return item;
            }
