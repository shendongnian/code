        List<ListViewItem> itemsToMove = new List<ListViewItem>();
        foreach (ListViewItem item in listView1.SelectedItems)
        {
            itemsToMove.Add(item);
        }
        foreach (ListViewItem item in itemsToMove)
        {
            listView1.Items.Remove(item);
            listView2.Items.Add(item);
        }
