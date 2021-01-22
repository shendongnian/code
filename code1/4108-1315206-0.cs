        private void triggerInstanceList_DragOver(object sender, DragEventArgs e)
        {
            SetDropEffect(e);
        }
        private void triggerInstanceList_DragEnter(object sender, DragEventArgs e)
        {
            SetDropEffect(e);
        }
        private void SetDropEffect(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem itemToDrop = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
                if (itemToDrop.Tag is TriggerTypeIdentifier)
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }
        private void triggerInstanceList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                try
                {
                    ListViewItem itemToDrop = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
                    if (itemToDrop.Tag is TriggerTypeIdentifier)
                    {
                        ListViewItem newItem = new ListViewItem("<new " + itemToDrop.Text + ">", itemToDrop.ImageIndex);
                        _triggerInstanceList.Items.Add(newItem);
                    }
                    else
                    {
                        _expiredTriggers.Items.Remove(itemToDrop);
                        _triggerInstanceList.Items.Add(itemToDrop);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
