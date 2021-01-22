    private void menuItem1_Click(object sender, EventArgs e)
    {
        MenuItem item = (sender as MenuItem);
        if (item != null)
        {
            ContextMenu owner = item.Parent as ContextMenu;
            if (owner != null)
            {
                MessageBox.Show(owner.SourceControl.Text);
            }
        }
    }
