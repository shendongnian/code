    foreach (DataRow row in data.Rows)
    {
        ListViewItem item = new ListViewItem(row[0].ToString());
        for (int i = 1; i < data.Columns.Count; i++)
        {
            item.SubItems.Add(row[i].ToString());
        }
        listView_Services.Items.Add(item);
    }
