    private void TreeViewCreateContextMenu(TreeNode node)
    {
        ContextMenuStrip contextMenu = new ContextMenuStrip();
    
        // create the menu items
        ToolStripMenuItem newMenuItem = new ToolStripMenuItem();
        newMenuItem.Text = "New...";
    
        // add the menu items to the menu
        contextMenu.Items.AddRange(new ToolStripMenuItem[] { newMenuItem });
    
        // add its event handler using a lambda expression, passing
        //  the additional parameter "myData"
        string myData = "This is the extra parameter.";
        newMenuItem.Click += (sender, e) => { newMenuItem_Click(sender, e, myData); };
    
        // finally, set the node's context menu
        node.ContextMenuStrip = contextMenu;
    }
    
    // the custom event handler, with "extraData":
    private void newMenuItem_Click(object sender, EventArgs e, string extraData)
    {
        // do something with "extraData"
    }
