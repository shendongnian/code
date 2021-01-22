    private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem li = listView1.SelectedItems[i];
                    listView1.Items.Remove(li);
                }
            }
        }
