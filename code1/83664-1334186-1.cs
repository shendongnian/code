    private void MenuStripItem_Click(object sender, EventArgs e)
    {
        ToolStripItem item = (sender as ToolStripItem);
        if (item != null)
        {
            ContextMenuStrip owner = item.Owner as ContextMenuStrip;
            if (owner != null)
            {
                MessageBox.Show(owner.SourceControl.Text);
            }
        }
    }
