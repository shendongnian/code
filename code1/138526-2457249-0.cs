        ListViewItem[] copyOfItemsInListView1 = new ListViewItem[listView1.Items.Count];
        ListViewItem[] copyOfItemsInListView2 = new ListViewItem[listView2.Items.Count];
        listView1.Items.CopyTo(copyOfItemsInListView1, 0);
        listView2.Items.CopyTo(copyOfItemsInListView2, 0);
        listView1.Items.Clear();
        listView2.Items.Clear();
        for (int i = 0; i < copyOfItemsInListView2.Length; i++)
        {
            listView1.Items.Add(copyOfItemsInListView2[i]);
        }
        for (int i = 0; i < copyOfItemsInListView1.Length; i++)
        {
            listView2.Items.Add(copyOfItemsInListView1[i]);
        }
