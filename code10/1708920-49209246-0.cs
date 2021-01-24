    for (int i = 1; i < 10; i++)
    {
        ListViewItem item = new ListViewItem(i.ToString());
        item.SubItems.Add(i.ToString());
        listView1.Items.Add(item);
    }
