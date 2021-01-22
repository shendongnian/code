      public void ExploreGraph(TreeNode tn, Dictionary<TreeNode, bool> visitednodes)
            {
    
                foreach (Treenode childnode in tn.Nodes)
                {
                    if (!visitedNodes.ContainsKey(childnode))
                    {
                        visitednodes.Add(childnode);
                        ExploreGraph(childnode, visitednodes);
                    }
                }
            }
