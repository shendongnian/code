    for (int i = 0; i < 20; i++)
    {
        ListViewItem item = new ListViewItem("Item" + i.ToString("00"));
        item.Name = "Item"+ i.ToString("00");
        listView1.Items.Add(item);
    }
    MessageBox.Show(listView1.Items.ContainsKey("Item00").ToString()); // True
    MessageBox.Show(listView1.Items.ContainsKey("Item20").ToString()); // False
