    // Make sure you include the using statement at the top of your code file.
    using System.Linq;
    void AddItem(string name, string serialNumber) {
        ListViewItem lvi = listView1.Items.Cast<ListViewItem>()
                                          .SingleOrDefault(s => s.Tag == serialNumber);
        if (lvi == null) {
            lvi = new ListViewItem(name);
            lvi.SubItems.Add(serialNumber);
            lvi.Tag = serialNumber;
            listView1.Items.Add(lvi);
        } else
            MessageBox.Show("Serial number supplied already exists.");
    }
