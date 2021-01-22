    /// <summary>
    /// Handle user dragging nodes in treeview
    /// </summary>
    private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
    {
        DoDragDrop(e.Item, DragDropEffects.Move);
    }
    /// <summary>
    /// Handle user dragging node into another node
    /// </summary>
    private void treeView1_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Move;
    }
    /// <summary>
    /// Handle user dropping a dragged node onto another node
    /// </summary>
    private void treeView1_DragDrop(object sender, DragEventArgs e)
    {
        // Retrieve the client coordinates of the drop location.
        Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
        // Retrieve the node that was dragged.
        TreeNode draggedNode = e.Data.GetData(typeof(TreeNode));
        
        // Sanity check
        if (draggedNode == null)
        {
            return;
        }
        // Retrieve the node at the drop location.
        TreeNode targetNode = treeView1.GetNodeAt(targetPoint);
        // Did the user drop the node 
        if (targetNode == null)
        {
            draggedNode.Remove();
            treeView1.Nodes.Add(draggedNode);
            draggedNode.Expand();
        }
        else
        {
            TreeNode parentNode = targetNode;
            // Confirm that the node at the drop location is not 
            // the dragged node and that target node isn't null
            // (for example if you drag outside the control)
            if (!draggedNode.Equals(targetNode) && targetNode != null)
            {
                bool canDrop = true;
                while (canDrop && (parentNode != null))
                {
                    canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
                    parentNode = parentNode.Parent;
                }
                if (canDrop)
                {
                    // Have to remove nodes before you can move them.
                    draggedNode.Remove();
                    // Is the user holding down shift?
                    if (e.KeyState == 4)
                    {
                        // Is the targets parent node null?
                        if (targetNode.Parent == null)
                        {
                            // The target node has no parent. That means 
                            // the target node is at the root level. We'll 
                            // insert the node at the root level below the 
                            // target node.
                            treeView1.Nodes.Insert(targetNode.Index + 1, draggedNode);
                        }
                        else 
                        {
                            // The target node has a valid parent so we'll 
                            // drop the node into it's index.
                            targetNode.Parent.Nodes.Insert(targetNode.Index + 1, draggedNode);
                        }
                    }
                    else
                    { 
                        targetNode.Nodes.Add(draggedNode);
                    }
                    targetNode.Expand();
                }
            }
        }
        // Optional: The following lines are an example of how you might
        // provide a better experience by highlighting and displaying the 
        // content of the dropped node. 
        // treeView1.SelectedNode = draggedNode;
        // NavigateToNodeContent(draggedNode.Tag); 
    }
