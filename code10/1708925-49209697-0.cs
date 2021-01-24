    List<ListViewItem> items = new List<ListViewItems>();
    for (int i = 1; i < 10; i++)
    {
        ListViewItem item = new ListViewItem(i.ToString());
        items.Add(item);
    }
    for (int i = 1; i < 10; i++)
    {
        items[i-1].SubItems.Add(i.ToString());
    }
    foreach(ListViewItem item in items)
    {
        listView1.Items.Add(item);
    }
