while (listView1.CheckedItems.Count > 0)
{
	ListViewItem item = listView1.CheckedItems[0];
	listView1.Items.Remove(item);
	listView2.Items.Add(item);
}
