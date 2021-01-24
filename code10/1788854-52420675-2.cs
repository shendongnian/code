    if (filterbox.Text == "")
    {
       return;
    }
    
    var list = listView1.Items
                        .Cast<ListViewItem>()
                        .Where(
                            x => x.SubItems
                                  .Cast<ListViewItem.ListViewSubItem>()
                                  .Any(y => y.Text.Equals(filterbox.Text, StringComparison.OrdinalIgnoreCase)))
                        .ToArray();
    listView1.Items.Clear();
    listView1.Items.AddRange(list);
