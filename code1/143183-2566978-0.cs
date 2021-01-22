    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            ListViewItem item = listView1.SelectedItems[0];
            MessageBox.Show(item.SubItems[2].ToString());
        }
    }
