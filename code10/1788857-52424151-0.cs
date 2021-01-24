    private void filterbox_TextChanged(object sender, EventArgs e)
    {
        listView1.Items.Clear();   // clear all items we have atm
        if (filterbox.Text == "")
        {
            listView1.Items.AddRange(allItems.ToArray());  // no filter: add all items
            return;
        }
        // now we find all items that have a suitable text in any subitem/field/column
        var list = allItems.Cast<ListViewItem>()
                           .Where( x => x.SubItems
                                         .Cast<ListViewItem.ListViewSubItem>()
                                         .Any(y => y.Text.Contains(filterbox.Text)))
                           .ToArray();
        listView1.Items.AddRange(list);  // now we add the result
    }
