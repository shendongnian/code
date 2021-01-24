    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Hide"));
            contextMenu.MenuItems.Add(new MenuItem("Show"));
            contextMenu.ItemClicked += new ToolStripItemClickedEventHandler(contexMenu_ItemClicked);
            contextMenu.Show(dataGridView1, new Point(e.X, e.Y));
    
        }
    }
