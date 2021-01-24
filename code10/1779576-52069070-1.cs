        listView1.Columns.Clear(); // Clear previously added columns
        listView1.Items.Clear(); // Clear previously populated items
        listView1.View = View.Details; // Set View property
        // Set Columns
        listView1.Columns.Add("Id"); 
        listView1.Columns.Add("Name");
        listView1.Columns.Add("Number");
        listView1.Columns.Add("Date");
        while(dr.Read())
        {
            ListViewItem lv = new ListViewItem(dr[0].ToString());
            lv.SubItems.Add(dr[1].ToString());
            lv.SubItems.Add(dr[2].ToString());
            lv.SubItems.Add(dr[3].ToString());
            listView1.Items.Add(lv);
        }
