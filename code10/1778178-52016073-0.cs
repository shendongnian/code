    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            ListViewItem currentitem = listView1.SelectedItems[0];
            label1.Text = currentitem.Text;
        }
        else
            label1.Text = string.Empty;
    }
