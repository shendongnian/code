        /// <summary>
        /// MoveComponentUpLinkButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MoveComponentUpLinkButton_Click(object sender, EventArgs e)
        {
            // Get the selected node
            TreeNode sourceNode = this.MyTreeview.SelectedNode;
            if (sourceNode != null)
            {
                // Get the selected node's parent
                TreeNode parentNode = this.MyTreeview.SelectedNode.Parent;
                if (parentNode != null)
                {
                    int index = -1;
                    // For each node in selected nodes parent
                    for (int j = 0; j < parentNode.ChildNodes.Count; j++)
                    {
                        // If we found the selected node
                        if (sourceNode == parentNode.ChildNodes[j])
                        {
                            // save index
                            index = j;
                            break;
                        }
                    }
                    // If node is not already at top of list
                    if (index > 0)
                    {
                        // Move it up
                        parentNode.ChildNodes.RemoveAt(index);
                        parentNode.ChildNodes.AddAt(index - 1, sourceNode);
                        sourceNode.Selected = true;
                    }
                }
            }
        }
        /// <summary>
        /// MoveComponentDownLinkButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MoveComponentDownLinkButton_Click(object sender, EventArgs e)
        {
            // Get the selected node
            TreeNode sourceNode = this.MyTreeview.SelectedNode;
            if (sourceNode != null)
            {
                // Get the selected node's parent
                TreeNode parentNode = this.MyTreeview.SelectedNode.Parent;
                if (parentNode != null)
                {
                    int index = -1;
                    // For each node in selected nodes parent
                    for (int j = 0; j < parentNode.ChildNodes.Count; j++)
                    {
                        // If we found the selected node
                        if (sourceNode == parentNode.ChildNodes[j])
                        {
                            // save index
                            index = j;
                            break;
                        }
                    }
                    // If node is not already at botton of list
                    if (index < parentNode.ChildNodes.Count - 1)
                    {
                        // Move it down
                        parentNode.ChildNodes.RemoveAt(index);
                        parentNode.ChildNodes.AddAt(index + 1, sourceNode);
                        sourceNode.Selected = true;
                    }
                }
            }
        }
