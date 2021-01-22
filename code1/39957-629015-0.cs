    private void listView1_MouseUp(object sender, MouseEventArgs e)
    {
        ListViewItem item = listView1.GetItemAt(0, e.Y);
        if (item == null)
        {
            MessageBox.Show("Null");
        }
        else
        {
            MessageBox.Show(item.Text);
        }
    }
