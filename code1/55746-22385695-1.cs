        private void btn_Merge_Click(object sender, EventArgs e)
        {
            //first merge
            foreach (TreeNode sourceNode in this.treeview_Source.Nodes)
            {
                FindOrAdd(sourceNode, ref this.treeview_Merged);
            }
            //second merge
            foreach (TreeNode targetNode in this.treeview_Target.Nodes)
            {
                FindOrAdd(targetNode, ref this.treeview_Merged);
            }
        }
        private void FindOrAdd(TreeNode FindMe, ref TreeView InHere)
        {
            TreeNode[] found = InHere.Nodes.FindExact(FindMe.Name);
            //if the node is not found, add it at the proper location.
            if (found.Length == 0)
            {
                if (FindMe.Parent != null)
                {
                    TreeNode[] foundParent = InHere.Nodes.FindExact(FindMe.Parent.Name);
                    if (foundParent.Length == 0)
                        InHere.Nodes.Add((TreeNode)FindMe.Clone());
                    else
                        foundParent[0].Nodes.Add((TreeNode)FindMe.Clone());
                }
                else
                    InHere.Nodes.Add((TreeNode)FindMe.Clone());
            }
            else
            {
                //if the item was found, check all children.
                foreach (TreeNode child in FindMe.Nodes)
                    FindOrAdd(child, ref InHere);
            }
        }
