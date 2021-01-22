    listView1.View = View.Details;
    //Set Columns
    listView1.Columns.Add("Col1");
    listView1.Columns.Add("Col2");
    listView1.Columns.Add("Col3");
    //Fill Rows
    ListViewItem lvi;            
    lvi = new ListViewItem(new string[] { "A", "B", "C" });
    listView1.Items.Add(lvi);
    lvi = new ListViewItem(new string[] { "D", "E", "F" });
    listView1.Items.Add(lvi);
    lvi = new ListViewItem(new string[] { "G", "H", "I" });
    listView1.Items.Add(lvi);
