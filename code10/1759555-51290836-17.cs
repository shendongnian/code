    List<ListViewItem> items = new List<ListViewItem>();
    for (int i = 0; i < 50000; i++) {
        ListViewItem lvi = new ListViewItem($"Some kind of text {i}.");
        lvi.Tag = i;
        items.Add(lvi);
    }
    listView1.Items.AddRange(items.ToArray());
