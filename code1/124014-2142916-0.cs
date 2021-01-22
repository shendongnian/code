        // the current Node in AfterSelect
        private TreeNode currentNode;
        // flag to prevent recursion
        private bool dontRecurse;
        // boolean used in testing if all child nodes are checked
        private bool isChecked;
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // prevent recursion here
            if (dontRecurse) return;
            // set the currentNode
            currentNode = e.Node;
            // for debugging
            //Console.WriteLine("after check node = " + currentNode.Text);
            // select or unselect the current node depending on checkstate
            if (currentNode.Checked)
            {
                treeView1.SelectedNode = currentNode;
            }
            else
            {
                treeView1.SelectedNode = null;
            }
            if(currentNode.Nodes.Count > 0)
            {
                // node with children : make the child nodes
                // checked state match the parents
                foreach (TreeNode theNode in currentNode.Nodes)
                {
                    theNode.Checked = currentNode.Checked;
                }
            }
            else
            {
                // assume a child node is selected here
                // i.e., we assume no root level nodes without children
                if (!currentNode.Checked)
                {
                    // the child node is unchecked : uncheck the parent node
                    dontRecurse = true;
                        currentNode.Parent.Checked = false;
                    dontRecurse = false;
                }
                else
                {
                    // the child node is checked : check the parent node 
                    // if all other siblings are checked
                    // check the parent node
                    dontRecurse = true;
                        isChecked = true;
                        foreach(TreeNode theNode in currentNode.Parent.Nodes)
                        {
                           if(theNode != currentNode)
                           {
                               if (!theNode.Checked) isChecked = false;
                           }
                        }
                        if (isChecked) currentNode.Parent.Checked = true;
                    dontRecurse = false;
                }
            }
        }
