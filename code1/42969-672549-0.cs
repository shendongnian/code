    ListViewItem itemClone;
    foreach (ListViewItem item in listView1.Items)
    {
    itemClone = item.Clone() as ListViewItem;
    listView2.Items.Add(itemClone);
    }
