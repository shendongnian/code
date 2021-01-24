    using System;
    using System.Windows.Forms;
    
    namespace MyTreeViewDemo
    {
        class MyTreeView : TreeView
        {
            public MyTreeView()
            {
                //This event handler does nothing more than select the node the user clicked
                this.NodeMouseClick += TreeViewTableList_NodeMouseClick;
            }
    
            // Associate a delegate with an event by including the delegate type in the event declaration
            // Declare an event named ContextMenuItemClicked. 
            // The event is associated with the EventHandler delegate and raised in a method named OnContextMenuItemClicked. 
            public event EventHandler ContextMenuItemClicked;
    
            /// <summary>
            /// When the user clicks on a treenode context menu item, this method is invoked
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            protected virtual void OnContextMenuItemClicked(object sender, EventArgs e)
            {
                // Do treeview stuff that needs to be done when a treenode context menu item is clicked
    
                //if EventHandler ContextMenuItemClicked is not null, invoke it so that subscribers are notified.
                ContextMenuItemClicked?.Invoke(sender, e);
            }
    
            /// <summary>
            /// Method to build a minimum treeview with one node
            /// </summary>
            public void Load()
            {
                TreeNode treeNodeRoot = new TreeNode("tree node item");
    
                this.Nodes.Add(treeNodeRoot);
    
                // Create a ContextMenuStrip for the tree node
                ContextMenuStrip contextMenuStripRootNode = new ContextMenuStrip
                {
                    ShowCheckMargin = true,
                    ShowImageMargin = false
                };
    
                //Create a menu item for the context menu. Set it to invoke OnContextMenuItemClicked when its clicked
                ToolStripMenuItem menuItem = new ToolStripMenuItem("foo", null, onClick: OnContextMenuItemClicked)
                {
                    CheckOnClick = true
                };
    
                //Add the menu item to the contextstrip.
                contextMenuStripRootNode.Items.Add(menuItem);
    
                //Set the tree node's ContextMenuStrip property to the ContextMenuStrip.
                treeNodeRoot.ContextMenuStrip = contextMenuStripRootNode;
            }
    
            /// <summary>
            ///  Select the node the user clicked so that the treeview visually looks as the user expects
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void TreeViewTableList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
            {
                TreeView t = (TreeView)sender;
                //Force the node that was clicked to be selected
                t.SelectedNode = t.GetNodeAt(e.X, e.Y);
            }
    
        }
    }
    
