    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem item = listBox1.SelectedItem as ListItem;
        if (item != null)
        {
            if (File.Exists(item.FullPath) ) rtb.LoadFile(item.FullPath);
        }
    }
