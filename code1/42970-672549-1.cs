    ListViewItem itemClone;
    ListView.ListViewItemCollection coll = listView1.Items;
    foreach (ListViewItem item in coll)
    {
    itemClone = item.Clone() as ListViewItem;
    listView1.Items.Remove(item);
    listView2.Items.Add(itemClone);
    }
