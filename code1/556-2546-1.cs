    void treeView1MouseUp(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Right)
        {
            // Select the clicked node
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            if(treeView1.SelectedNode != null)
            {
                myContextMenuStrip.Show(treeView1, e.Location);
            }
        }
    }
