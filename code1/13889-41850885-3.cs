    private void myContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        ToolStripItem item = e.ClickedItem;
        //////////// This will show "nameOfMenuItem":
        MessageBox.Show(item.Name, "And the clicked option is...");
    }
