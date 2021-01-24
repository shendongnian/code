    private void DocumentActionToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
    {
        Control treeNodeControl;
    
        ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
    
        // if the ToolStripMenuItem item is owned by a ContextMenuStrip ...
        if (toolStripMenuItem.Owner is ContextMenuStrip contextMenuStrip)
        {
            // Get the TreeNode that is displaying this context menu
            treeNodeControl = contextMenuStrip.SourceControl;
    
            if (toolStripMenuItem.CheckState == CheckState.Checked)
            {
                //Do something with treeNodeControl.SelectedNode treeView node
            }
        }
    
    }
