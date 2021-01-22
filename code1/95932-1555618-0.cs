        foreach (row r in collection)
        {
            ListViewItem item = new ListViewItem();
            item.Text = r.field1; //this will be col1
            item.SubItems.Add(r.field2); //col2 
            item.SubItems.Add(r.field3); //col3
            listView1.Items.Add(item);
        }
