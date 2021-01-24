    // Make sure you include the using statement at the top of your code file.
    using System.Linq;
    private void populate(string employeeid, string, sn, string timestamp) {
        ListViewItem lvi = listView1.Items.Cast<ListViewItem>()
                                          .SingleOrDefault(s => s.Tag == sn);
        if (lvi == null) {
            lvi = new ListViewItem(employeeid);
            lvi.SubItems.Add(sn);
            lvi.SubItems.Add(timestamp);
            lvi.Tag = sn;
            listView1.Items.Add(lvi);
        } else
            MessageBox.Show("Serial number supplied already exists.");
    }
