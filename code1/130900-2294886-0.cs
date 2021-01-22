       void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the node at the current mouse pointer location.
            TreeNode theNode = this.treeView1.GetNodeAt(e.X, e.Y);
            // Set a ToolTip only if the mouse pointer is actually paused on a node.
            if ((theNode != null))
            {
                // Verify that the tag property is not "null".
                if (theNode.Tag != null)
                {
                    // Change the ToolTip only if the pointer moved to a new node.
                    if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.treeView1))
                    {
                        //this.toolTip1.SetToolTip(this.treeView1, theNode.Tag.ToString());
                        Point c = System.Windows.Forms.Cursor.Position;
                        Point p = treeView1.PointToClient(c);
                        this.toolTip1.Show(theNode.Tag.ToString(), treeView1, p);
                    }
                }
                else
                {
                    this.toolTip1.SetToolTip(this.treeView1, "");
                }
            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.toolTip1.SetToolTip(this.treeView1, "");
            }
        }
