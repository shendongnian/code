    private void treeView_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            treeView.SelectedNode = treeView.GetNodeAt(e.Location);
        }
    }
