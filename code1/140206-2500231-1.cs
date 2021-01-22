    public class TotalingTreeNode : TreeNode
    {
        public int GetTotaledValue()
        {
            int total = 0;
            foreach (TotalingTreeNode t in this.Nodes.Cast<TotalingTreeNode>())
            {
                total += t.GetTotaledValue()
            }
            return total;
        }
    }
