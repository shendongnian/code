    private TreeView MergeTreeViews(TreeView tv1, TreeView tv2)
    {
        var result = new TreeView();
        foreach (TreeNode node in tv2.Nodes)
        {
            result.Nodes.Add(node.Clone() as TreeNode);
        }
        foreach (TreeNode node in tv1.Nodes)
        {
            var nodeOnOtherSide = result.Nodes.ToEnumerable()
                .SingleOrDefault(tr => tr.Text == node.Text);
            if (nodeOnOtherSide == null)
            {
                TreeNode clone = node.Clone() as TreeNode;
                result.Nodes.Add(clone);
            }
            else
            {
                var n = node.Nodes.ToEnumerable()
                         .Where(t => !(nodeOnOtherSide.Nodes.ToEnumerable()
                         .Contains(t, new TreeNodeComparer())));
                foreach (TreeNode subNode in n)
                {
                    TreeNode clone = subNode.Clone() as TreeNode;
                    nodeOnOtherSide.Nodes.Add(clone);
                }
            }
        }
        return result;
    }
