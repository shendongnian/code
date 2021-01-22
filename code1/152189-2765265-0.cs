    foreach (DataRow row in data.Rows)
    {
        ListViewItem item = new ListViewItem();
        for (int i = 0; i < data.Columns.Count; i++)
        {
            item.SubItems.Add(row[i].ToString());
        }
        listView_Services.Items.Add(item);
    }
