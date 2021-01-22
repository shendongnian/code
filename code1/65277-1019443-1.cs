    private void listView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A && e.Control)
        {
            listView1.MultiSelect = true;
            foreach (ListViewItem item in listView1.Items)
            {
                item.Selected = true;
            }
        }
    }
